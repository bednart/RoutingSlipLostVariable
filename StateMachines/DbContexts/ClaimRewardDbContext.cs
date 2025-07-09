using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;

namespace RoutingSlipLostVariable.StateMachines.DbContexts;

internal class ClaimRewardDbContext(DbContextOptions options) : SagaDbContext(options)
{
    protected override IEnumerable<ISagaClassMap> Configurations => [new ClaimRewardDbContextInstanceMap()];
}
