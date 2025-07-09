using MassTransit;

namespace RoutingSlipLostVariable.StateMachines.Providers;

internal class CustomEndpointNameFormatter :
    IEndpointNameFormatter
{
    private readonly IEndpointNameFormatter _formatter;

    public CustomEndpointNameFormatter()
    {
        _formatter = KebabCaseEndpointNameFormatter.Instance;
    }

    public string TemporaryEndpoint(string tag)
    {
        return AddPrefix(_formatter.TemporaryEndpoint(tag));
    }

    public string Consumer<T>()
        where T : class, IConsumer
    {
        return AddPrefix(_formatter.Consumer<T>());
    }

    public string Message<T>()
        where T : class
    {
        return AddPrefix(_formatter.Message<T>());
    }

    public string Saga<T>()
        where T : class, ISaga
    {
        return AddPrefix(_formatter.Saga<T>());
    }

    public string ExecuteActivity<T, TArguments>()
        where T : class, IExecuteActivity<TArguments>
        where TArguments : class
    {
        string executeActivity = _formatter.ExecuteActivity<T, TArguments>();

        return SanitizeName(executeActivity);
    }

    public string CompensateActivity<T, TLog>()
        where T : class, ICompensateActivity<TLog>
        where TLog : class
    {
        string compensateActivity = _formatter.CompensateActivity<T, TLog>();

        return SanitizeName(compensateActivity);
    }

    public string SanitizeName(string name)
    {
        return AddPrefix(_formatter.SanitizeName(name));
    }

    public string Separator => _formatter.Separator;

    private static string AddPrefix(string name)
    {
        return $"sbq-{name}";
    }
}
