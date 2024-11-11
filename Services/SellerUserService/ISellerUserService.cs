public interface ISellerUserService
{
    Task<Result<PaginationResponse<IEnumerable<ReadSellerUserInfo>>>> GetAll(BaseFilter filter);
    Task<Result<ReadSellerUserInfo>> GetById(int id);
    Task<Result<bool>> Create(CreateSellerUserInfo createSeller);
    Task<Result<bool>> Update(UpdateSellerUserInfo updateSeller);
    Task<Result<bool>> Delete(int id);
    // Task<GetSellerAndProducts> GetByIdSellerAndProducts(int id);
}