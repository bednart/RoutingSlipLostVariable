using MassTransit;
using MassTransit.Courier.Contracts;
using RoutingSlipLostVariable.StateMachines.Activities;
using RoutingSlipLostVariable.StateMachines.Contracts;
using RoutingSlipLostVariable.StateMachines.Providers;

namespace RoutingSlipLostVariable.StateMachines.Consumers;

public class ClaimRewardProcessConsumer(
    IEndpointAddressProvider _provider
    ) :
    IConsumer<ClaimRewardProcess>
{
    private static readonly string ValidateClaimedRewardActivityName = "ValidateClaimedReward";

    public async Task Consume(ConsumeContext<ClaimRewardProcess> context)
    {
        RoutingSlip routingSlip = await CreateRoutingSlip(context);

        await context.Execute(routingSlip);
    }

    private async Task<RoutingSlip> CreateRoutingSlip(ConsumeContext<ClaimRewardProcess> context)
    {
        RoutingSlipBuilder builder = new(NewId.NextGuid());

        builder.SetVariables(new
        {
            context.Message.SubmissionId,
            context.Message.CustomerGuid,
            context.Message.RewardId
        });

        builder.AddActivity(ValidateClaimedRewardActivityName,
            _provider.GetExecuteEndpoint<ValidateClaimedRewardActivity, ValidateClaimedRewardArguments>());

        await builder.AddSubscription(context.SourceAddress,
            RoutingSlipEvents.ActivityFaulted,
            RoutingSlipEventContents.Variables,
            ValidateClaimedRewardActivityName,
            x => x.Send<ValidateClaimedRewardFailed>(new { context.Message.SubmissionId },
            context.CancellationToken));

        return builder.Build();
    }
}
