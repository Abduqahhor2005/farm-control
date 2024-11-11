using System.Linq.Expressions;

namespace FarmControl.Base.BaseRepository.BaseQueryGenericRepository;

public interface IQueryGenericRepository<TQuery>
{
    Task<TQuery?> GetByIdAsync(int id);
    Task<IEnumerable<TQuery>> GetAllAsync();
    Task<IEnumerable<TQuery>> FindAsync(Expression<Func<TQuery, bool>> expression);
}