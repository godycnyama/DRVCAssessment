using Roulette.Application.Abstractions.Repositories;
using Roulette.Domain.Entities;
using Roulette.Infrastructure.Persistence.Context;

namespace Roulette.Infrastructure.Persistence.Repositories;
public class PayoutRepository : GenericRepository<Payout>, IPayoutRepository
{
    public PayoutRepository(RouletteDataContext dbContext) : base(dbContext)
    {
    }
}
