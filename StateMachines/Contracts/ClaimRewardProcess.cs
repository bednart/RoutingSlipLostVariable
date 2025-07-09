namespace RoutingSlipLostVariable.StateMachines.Contracts;

public sealed record ClaimRewardProcess
{
    public Guid SubmissionId { get; init; }

    public string CustomerGuid { get; init; }

    public string RewardId { get; init; }
}
