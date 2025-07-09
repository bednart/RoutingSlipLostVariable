# RoutingSlipLostVariable

This is a sample project to demonstrate the issue with lost variables in routing slip if FaultedWithVariables is returned from activity and 
more than 1 retry is configured using UseDelayedRedelivery.

## Steps to reproduce

- Clone the repository.
- Set TestDb connection string in appsettings.json (SqlServer is used).

## Successful scenario

- Set RedeliveryNumber in appsettings.json to 1.
- Run project and send request using RoutingSlipLostVariable.http
- ClaimRewardStateMachineExtensions.SetFault() method will log 
```
RESULT -> ExceptionInfo: UglyError | Variable: UglyError
```
- In this case, the Variables dictionary contains `errorMessage` property.

## Failed scenario

- Set RedeliveryNumber in appsettings.json to 2 or higher.
- Run project and send request using RoutingSlipLostVariable.http
- ClaimRewardStateMachineExtensions.SetFault() method will log 
```
RESULT -> ExceptionInfo: UglyError | Variable: (null)
```
- In this case, the Variables dictionary does not contains `errorMessage` property.