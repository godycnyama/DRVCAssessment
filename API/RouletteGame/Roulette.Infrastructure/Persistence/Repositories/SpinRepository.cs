using Roulette.Application.Abstractions.Repositories;
using Roulette.Domain.Entities;
using Roulette.Infrastructure.Persistence.Context;

namespace Roulette.Infrastructure.Persistence.Repositories;
public class SpinRepository : GenericRepository<Spin>, ISpinRepository
{
    public SpinRepository(RouletteDataContext dbContext) : base(dbContext)
    {
    }
}
