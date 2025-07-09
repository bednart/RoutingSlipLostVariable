using MassTransit;

namespace RoutingSlipLostVariable.StateMachines.Providers;

internal class ServiceBusEndpointAddressProvider(
    IEndpointNameFormatter _formatter
    ) :
    IEndpointAddressProvider
{
    public Uri GetExecuteEndpoint<T, TArguments>()
        where T : class, IExecuteActivity<TArguments>
        where TArguments : class
    {
        return new Uri($"exchange:{_formatter.ExecuteActivity<T, TArguments>()}");
    }
}
