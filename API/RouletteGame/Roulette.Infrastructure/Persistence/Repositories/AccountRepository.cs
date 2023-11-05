using Roulette.Application.Abstractions.Repositories;
using Roulette.Domain.Entities;
using Roulette.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Infrastructure.Persistence.Repositories;
public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    public AccountRepository(RouletteDataContext dbContext) : base(dbContext)
    {
    }
}
