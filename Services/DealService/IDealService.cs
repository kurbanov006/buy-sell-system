public interface IDealService
{
    Task<Result<PaginationResponse<IEnumerable<ReadDealInfo>>>> GetAll(BaseFilter filter);
    Task<Result<ReadDealInfo>> GetById(int id);
    Task<Result<bool>> Create(CreateDealInfo deal);
    Task<Result<bool>> Update(UpdateDealInfo deal);
    Task<Result<bool>> Delete(int id);
}