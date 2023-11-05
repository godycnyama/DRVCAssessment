using Microsoft.EntityFrameworkCore;
using Roulette.Domain.Entities;

namespace Roulette.Infrastructure.Persistence.Context;
public  class RouletteDataContext: DbContext
{
    public RouletteDataContext(DbContextOptions<RouletteDataContext> options) : base(options)
    {
    }

    public DbSet<Bet> Bets { get; set; }
    public DbSet<Spin> Spins { get; set; }
    public DbSet<Account> Deposits { get; set; }
    public DbSet<Payout> Payouts { get; set; }
}
