using Microsoft.EntityFrameworkCore;
using RoutingSlipLostVariable.StateMachines.DbContexts;
using RoutingSlipLostVariable.StateMachines.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddStateMachine(builder.Configuration);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using IServiceScope scope = app.Services.CreateScope();
await using ClaimRewardDbContext dbContext = scope.ServiceProvider.GetRequiredService<ClaimRewardDbContext>();
await dbContext.Database.MigrateAsync();

await app.RunAsync();