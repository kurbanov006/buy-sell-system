public interface IReviewService
{
    Task<Result<PaginationResponse<IEnumerable<ReadReviewInfo>>>> GetAll(BaseFilter filter);
    Task<Result<ReadReviewInfo>> GetById(int id);
    Task<Result<bool>> Create(CreateReviewInfo review);
    Task<Result<bool>> Update(UpdateReviewInfo review);
    Task<Result<bool>> Delete(int id);
}