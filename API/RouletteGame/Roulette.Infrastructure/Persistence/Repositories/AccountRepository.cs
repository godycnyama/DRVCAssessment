using Roulette.Application.Abstractions.Repositories;
using Roulette.Domain.Entities;
using Roulette.Infrastructure.Persistence.Context;

namespace Roulette.Infrastructure.Persistence.Repositories;
public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    public AccountRepository(RouletteDataContext dbContext) : base(dbContext)
    {
    }
}
