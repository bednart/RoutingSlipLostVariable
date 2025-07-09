using System.Reflection;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using RoutingSlipLostVariable.StateMachines.DbContexts;
using RoutingSlipLostVariable.StateMachines.Providers;

namespace RoutingSlipLostVariable.StateMachines.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStateMachine(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ClaimRewardDbContext>(r =>
        {
            r.UseSqlServer(configuration.GetConnectionString("TestDb"));
        });

        services.AddSingleton<IEndpointAddressProvider, ServiceBusEndpointAddressProvider>();

        services.AddMassTransit(mt =>
        {
            mt.SetEntityFrameworkSagaRepositoryProvider(r =>
            {
                r.ExistingDbContext<ClaimRewardDbContext>();
                r.UseSqlServer();
            });

            // configure queues retry policies
            mt.AddConfigureEndpointsCallback((_, _, cfg) =>
            {
                cfg.UseDelayedRedelivery(r =>
                {
                    r.Interval(configuration.GetValue<int>("RedeliveryNumber"), TimeSpan.FromSeconds(1));
                });
            });

            mt.SetEndpointNameFormatter(new CustomEndpointNameFormatter());

            Assembly assembly = Assembly.GetExecutingAssembly();

            mt.AddConsumers(assembly);
            mt.AddActivities(assembly);
            mt.AddSagaStateMachines(assembly);

            mt.UsingInMemory((context, cfg) =>
            {
                cfg.UseInMemoryOutbox(context);

                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
