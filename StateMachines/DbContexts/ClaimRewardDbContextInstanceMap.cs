using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RoutingSlipLostVariable.StateMachines.DbContexts;

internal class ClaimRewardDbContextInstanceMap :
    SagaClassMap<ClaimRewardState>
{
    protected override void Configure(EntityTypeBuilder<ClaimRewardState> entity, ModelBuilder model)
    {
        entity.ToTable("ClaimedRewards");
    }
}
