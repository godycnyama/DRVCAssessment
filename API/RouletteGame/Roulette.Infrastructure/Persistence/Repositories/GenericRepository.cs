using Microsoft.EntityFrameworkCore;
using Roulette.Application.Abstractions.Repositories;
using Roulette.Infrastructure.Persistence.Context;
using System.Linq.Expressions;

namespace Roulette.Infrastructure.Persistence.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly RouletteDataContext _dbContext;
    private readonly DbSet<T> _entitiySet;

    public GenericRepository(RouletteDataContext dbContext)
    {
        _dbContext = dbContext;
        _entitiySet = _dbContext.Set<T>();
    }

    public void Add(T entity)
        => _dbContext.Add(entity);

    public async Task AddAsync(T entity)
        => await _dbContext.AddAsync(entity);

    public void AddRange(IEnumerable<T> entities)
        => _dbContext.AddRange(entities);

    public async Task AddRangeAsync(IEnumerable<T> entities)
        => await _dbContext.AddRangeAsync(entities);

    public T Get(Expression<Func<T, bool>> expression)
        => _entitiySet.FirstOrDefault(expression);

    public async Task<T> Get(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public IEnumerable<T> GetAll()
        => _entitiySet.AsEnumerable();

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        => _entitiySet.Where(expression).AsEnumerable();

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _entitiySet.ToListAsync();

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        => await _entitiySet.Where(expression).ToListAsync();

    public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        => await _entitiySet.FirstOrDefaultAsync(expression);

    public void Remove(T entity)
        => _dbContext.Remove(entity);

    public void RemoveRange(IEnumerable<T> entities)
        => _dbContext.RemoveRange(entities);

    public void Update(T entity)
        => _dbContext.Update(entity);

    public void UpdateRange(IEnumerable<T> entities)
        => _dbContext.UpdateRange(entities);
}
