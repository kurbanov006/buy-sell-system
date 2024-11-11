public interface ICountryService
{
    Task<Result<PaginationResponse<IEnumerable<ReadCountryInfo>>>> GetAll(BaseFilter filter);
    Task<Result<ReadCountryInfo>> GetById(int id);
    Task<Result<bool>> Create(CreateCountryInfo country);
    Task<Result<bool>> Update(UpdateCountryInfo country);
    Task<Result<bool>> Delete(int id);
}