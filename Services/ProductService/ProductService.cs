
public class ProductService(IUnitOfWork<Product> unitOfWork) : IProductService
{
    public async Task<Result<bool>> Create(CreateProductInfo product)
    {
        await unitOfWork.ProductRepository.Create(product.CreateToProduct());
        int res = unitOfWork.Complete();
        return res is 0
        ? Result<bool>.Success(true)
        : Result<bool>.Failure(Error.BadRequest());
    }

    public async Task<Result<bool>> Delete(int id)
    {
        Result<Product> product = await unitOfWork.ProductRepository.GetById(id);
        if (product.Value is null)
            return Result<bool>.Failure(Error.NotFound());

        product.Value.ToDeleted();
        int res = unitOfWork.Complete();
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Failure(Error.BadRequest());
    }

    public async Task<Result<PaginationResponse<IEnumerable<ReadProductInfo>>>> GetAll(BaseFilter filter)
    {
        Result<IEnumerable<Product>> products = await unitOfWork.ProductRepository.GetAll(filter);

        if (products is null)
            return Result<PaginationResponse<IEnumerable<ReadProductInfo>>>.Failure(Error.NotFound());

        IEnumerable<ReadProductInfo> res = products.Value!
        .Skip((filter.PageNumber - 1) * filter.PageSize)
        .Take(filter.PageSize)
        .Select(x => x.ToRead())
        .ToList();

        int count = res.Count();

        PaginationResponse<IEnumerable<ReadProductInfo>> response =
         PaginationResponse<IEnumerable<ReadProductInfo>>.Create(filter.PageNumber, filter.PageSize, count, res);

        return Result<PaginationResponse<IEnumerable<ReadProductInfo>>>.Success(response);
    }

    public async Task<Result<ReadProductInfo>> GetById(int id)
    {
        Result<Product> result = await unitOfWork.ProductRepository.GetById(id);
        if (result.Value is null)
            return Result<ReadProductInfo>.Failure(Error.NotFound());

        if (result.Value.IsDeleted == false)
            return Result<ReadProductInfo>.Success(result.Value.ToRead());
        return Result<ReadProductInfo>.Failure(Error.NotFound());
    }

    public async Task<Result<bool>> Update(UpdateProductInfo product)
    {
        Result<Product> productUpdate = await unitOfWork.ProductRepository.GetById(product.Id);
        if (productUpdate.Value is null)
            return Result<bool>.Failure(Error.NotFound());

        productUpdate.Value.UpdateProduct(product);
        int res = unitOfWork.Complete();
        return res > 0
        ? Result<bool>.Failure(Error.BadRequest())
        : Result<bool>.Success(true);
    }
}