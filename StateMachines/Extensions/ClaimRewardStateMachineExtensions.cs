using MassTransit;
using RoutingSlipLostVariable.StateMachines.Contracts;

namespace RoutingSlipLostVariable.StateMachines.Extensions;

internal static class ClaimRewardStateMachineExtensions
{
    public static EventActivityBinder<ClaimRewardState, ClaimRewardRequested> Initialize(
        this EventActivityBinder<ClaimRewardState, ClaimRewardRequested> binder)
    {
        return binder.Then(context =>
        {
            context.Saga.CustomerGuid = context.Message.CustomerGuid;
            context.Saga.RewardId = context.Message.RewardId;
        });
    }

    public static EventActivityBinder<ClaimRewardState, ClaimRewardRequested> Process(
        this EventActivityBinder<ClaimRewardState, ClaimRewardRequested> binder)
    {
        return binder.PublishAsync(context => context.Init<ClaimRewardProcess>(context.Message));
    }

    public static EventActivityBinder<ClaimRewardState, ValidateClaimedRewardFailed> SetFault(
        this EventActivityBinder<ClaimRewardState, ValidateClaimedRewardFailed> binder)
    {
        return binder.Then(context =>
        {
            LogContext.Info?.Log("RESULT -> ExceptionInfo: {0} | Variable: {0}", context.Message.ExceptionInfo?.Message, context.Message.ErrorMessage);
        });
    }
}
