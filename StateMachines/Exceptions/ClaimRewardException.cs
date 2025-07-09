namespace RoutingSlipLostVariable.StateMachines.Exceptions;

public sealed class ClaimRewardException : Exception
{
    public ClaimRewardException()
    {
    }

    public ClaimRewardException(string message)
        : base(message)
    {
    }

    public ClaimRewardException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
