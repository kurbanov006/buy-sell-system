public interface IProductService
{
    Task<Result<PaginationResponse<IEnumerable<ReadProductInfo>>>> GetAll(BaseFilter filter);
    Task<Result<ReadProductInfo>> GetById(int id);
    Task<Result<bool>> Create(CreateProductInfo product);
    Task<Result<bool>> Update(UpdateProductInfo product);
    Task<Result<bool>> Delete(int id);
}