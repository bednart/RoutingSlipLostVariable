using MassTransit;

namespace RoutingSlipLostVariable.StateMachines.Contracts;

public abstract record ContractWithVariables
{
    public IDictionary<string, object>? Variables { get; init; }

    protected T? GetVariableData<T>(string key)
    {
        if (Variables is not null &&
            Variables.TryGetValue(key, out object? value) &&
            value is T typedValue)
        {
            return typedValue;
        }

        return default;
    }
}
