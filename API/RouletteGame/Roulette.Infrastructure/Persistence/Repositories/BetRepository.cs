using Roulette.Application.Abstractions.Repositories;
using Roulette.Domain.Entities;
using Roulette.Infrastructure.Persistence.Context;

namespace Roulette.Infrastructure.Persistence.Repositories;
public class BetRepository : GenericRepository<Bet>, IBetRepository
{
    public BetRepository(RouletteDataContext dbContext) : base(dbContext)
    {
    }
}
