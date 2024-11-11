
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : BaseEntity
{
    public async Task<Result<bool>> Create(T value)
    {
        await context.Set<T>().AddAsync(value);
        int res = await context.SaveChangesAsync();
        return res > 0
         ? Result<bool>.Success(true)
         : Result<bool>.Failure(Error.BadRequest());
    }

    public async Task<Result<IEnumerable<T>>> GetAll(BaseFilter filter)
    {
        List<T> res = await context.Set<T>().Where(x => x.IsDeleted == false).ToListAsync();
        return Result<IEnumerable<T>>.Success(res);
    }

    public async Task<Result<T>> GetById(int id)
    {
        T? values = await context.Set<T>().FindAsync(id);
        return values is null
        ? Result<T>.Failure(Error.NotFound())
        : Result<T>.Success(values);
    }

    public async Task<Result<bool>> Update(T value)
    {
        context.Set<T>().Update(value);
        int res = await context.SaveChangesAsync();
        return res > 0
         ? Result<bool>.Success(true)
         : Result<bool>.Failure(Error.BadRequest());
    }
}