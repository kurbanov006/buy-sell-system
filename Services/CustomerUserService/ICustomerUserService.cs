public interface ICustomerUserService
{
    Task<Result<PaginationResponse<IEnumerable<ReadCustomerUserInfo>>>> GetAll(BaseFilter filter);
    Task<Result<ReadCustomerUserInfo>> GetById(int id);
    Task<Result<bool>> Create(CreateCustomerUserInfo customerUser);
    Task<Result<bool>> Update(UpdateCustomerUserInfo customerUser);
    Task<Result<bool>> Delete(int id);
}