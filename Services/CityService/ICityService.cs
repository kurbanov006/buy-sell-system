public interface ICityService
{
    Task<Result<PaginationResponse<IEnumerable<ReadCityInfo>>>> GetAll(BaseFilter filter);
    Task<Result<ReadCityInfo>> GetById(int id);
    Task<Result<bool>> Create(CreateCityInfo city);
    Task<Result<bool>> Update(UpdateCityInfo city);
    Task<Result<bool>> Delete(int id);
}