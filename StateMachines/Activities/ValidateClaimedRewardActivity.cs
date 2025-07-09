using MassTransit;
using RoutingSlipLostVariable.StateMachines.Exceptions;

namespace RoutingSlipLostVariable.StateMachines.Activities;

public class ValidateClaimedRewardActivity :
    IExecuteActivity<ValidateClaimedRewardArguments>
{
    public async Task<ExecutionResult> Execute(ExecuteContext<ValidateClaimedRewardArguments> context)
    {
        await Task.Delay(1);

        string errorMessage = "UglyError";
        return context.FaultedWithVariables(new ClaimRewardException(errorMessage), new
        {
            ErrorMessage = errorMessage
        });
    }
}
