public interface IGenericRepository<T>
{
    Task<Result<bool>> Create(T value);
    Task<Result<bool>> Update(T value);
    Task<Result<IEnumerable<T>>> GetAll(BaseFilter filter);
    Task<Result<T>> GetById(int id);
}