using MassTransit;
using RoutingSlipLostVariable.StateMachines.Contracts;
using RoutingSlipLostVariable.StateMachines.Extensions;

namespace RoutingSlipLostVariable.StateMachines;

public class ClaimRewardStateMachine : MassTransitStateMachine<ClaimRewardState>
{
    public ClaimRewardStateMachine()
    {
        InstanceState(x => x.CurrentState);

        Event(() => ClaimRewardRequestedEvent, x => x.CorrelateById(context => context.Message.SubmissionId));
        Event(() => ValidateClaimedRewardFailedEvent, x => x.CorrelateById(context => context.Message.SubmissionId));

        Initially(
            When(ClaimRewardRequestedEvent)
                .Initialize()
                .Process()
                .TransitionTo(Received));

        During(Received,
            When(ValidateClaimedRewardFailedEvent)
                .SetFault()
                .TransitionTo(Failed));
    }

    public State Received { get; }

    public State Failed { get; }

    public Event<ClaimRewardRequested> ClaimRewardRequestedEvent { get; }

    public Event<ValidateClaimedRewardFailed> ValidateClaimedRewardFailedEvent { get; }
}
