using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Roulette.Application.Abstractions.Repositories;
using Roulette.Application.Abstractions.Services;
using Roulette.Application.Abstractions.UnitOfWork;
using Roulette.Infrastructure.Persistence.Context;
using Roulette.Infrastructure.Persistence.Repositories;
using Roulette.Infrastructure.Persistence.UnitOfWork;
using Roulette.Infrastructure.Services;

namespace Roulette.Infrastructure;
public static class ServiceExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Sqlite");
        services.AddDbContext<RouletteDataContext>(opt => opt.UseSqlite(connectionString));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBetRepository, BetRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IPayoutRepository, PayoutRepository>();
        services.AddScoped<ISpinRepository, SpinRepository>();
        services.AddScoped<IBetService, BetService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ISpinService, SpinService>();
        services.AddScoped<IPayoutService, PayoutService>();
    }

}
