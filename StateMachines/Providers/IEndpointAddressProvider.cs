using MassTransit;

namespace RoutingSlipLostVariable.StateMachines.Providers;

public interface IEndpointAddressProvider
{
    Uri GetExecuteEndpoint<T, TArguments>()
        where T : class, IExecuteActivity<TArguments>
        where TArguments : class;
}
