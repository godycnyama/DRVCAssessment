using Roulette.Application.Abstractions.Repositories;
using Roulette.Domain.Entities;
using Roulette.Infrastructure.Persistence.Context;

namespace Roulette.Infrastructure.Persistence.Repositories;
public class SessionRepository : GenericRepository<Session>, ISessionRepository
{
    public SessionRepository(RouletteDataContext dbContext) : base(dbContext)
    {
    }
}
