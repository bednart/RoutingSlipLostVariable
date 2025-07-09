namespace RoutingSlipLostVariable.StateMachines.Contracts;

public sealed record ClaimRewardRequested
{
    public required Guid SubmissionId { get; init; }

    public required string CustomerGuid { get; init; }

    public required string RewardId { get; init; }
}
