namespace RoutingSlipLostVariable.StateMachines.Activities;


public sealed class ValidateClaimedRewardArguments
{
    public Guid SubmissionId { get; init; }

    public string CustomerGuid { get; init; }

    public string RewardId { get; init; }
}
