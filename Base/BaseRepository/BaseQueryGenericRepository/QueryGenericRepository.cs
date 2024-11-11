using System.Linq.Expressions;
using FarmControl.Base.BaseEntities;
using FarmControl.Base.Data;
using Microsoft.EntityFrameworkCore;

namespace FarmControl.Base.BaseRepository.BaseQueryGenericRepository;

public class QueryGenericRepository<TQuery>(BaseDbContext context)
    : IQueryGenericRepository<TQuery> where TQuery : BaseEntity
{
    public async Task<TQuery?> GetByIdAsync(int id)
    {
        return await context.Set<TQuery>().Where(x=>!x.IsDeleted).FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<IEnumerable<TQuery>> GetAllAsync()
    {
        return await context.Set<TQuery>().Where(x=>!x.IsDeleted).ToListAsync();
    }

    public async Task<IEnumerable<TQuery>> FindAsync(Expression<Func<TQuery, bool>> expression)
    {
        return await context.Set<TQuery>().Where(expression).Where(x=>!x.IsDeleted).ToListAsync();
    }
}