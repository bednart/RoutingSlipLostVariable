using MassTransit;

namespace RoutingSlipLostVariable.StateMachines;

public sealed class ClaimRewardState
    : SagaStateMachineInstance
{
    public Guid CorrelationId { get; set; }

    public string CurrentState { get; set; } = string.Empty;

    public string CustomerGuid { get; set; } = string.Empty;

    public string RewardId { get; set; } = string.Empty;

    public string? ExecutionError { get; set; }
}
