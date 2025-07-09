using MassTransit;

namespace RoutingSlipLostVariable.StateMachines.Contracts;

public sealed record ValidateClaimedRewardFailed : ContractWithVariables
{
    public Guid SubmissionId { get; init; }

    public string? ErrorMessage => GetVariableData<string?>(nameof(ErrorMessage));

    public ExceptionInfo? ExceptionInfo { get; init; }
}
