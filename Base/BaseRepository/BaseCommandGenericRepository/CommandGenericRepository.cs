using System.Linq.Expressions;
using FarmControl.Base.BaseEntities;
using FarmControl.Base.Data;
using Microsoft.EntityFrameworkCore;

namespace FarmControl.Base.BaseRepository.BaseCommandGenericRepository;

public class CommandGenericRepository<TCommand>(BaseDbContext context)
    :ICommandGenericRepository<TCommand> where TCommand : BaseEntity
{
    public async Task<int> AddAsync(TCommand command)
    {
        await context.Set<TCommand>().AddAsync(command);
        return await context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(TCommand command)
    {
        context.Set<TCommand>().Update(command);
        return await context.SaveChangesAsync();
    }

    public async Task<int> RemoveAsync(TCommand command)
    {
        context.Set<TCommand>().Remove(command);
        return await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TCommand>> FindAsync(Expression<Func<TCommand, bool>> expression)
    {
        return await context.Set<TCommand>().Where(expression).Where(x=>!x.IsDeleted).ToListAsync();
    }
}