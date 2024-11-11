
public class ReviewService(IUnitOfWork<Review> unitOfWork) : IReviewService
{
    public async Task<Result<bool>> Create(CreateReviewInfo review)
    {
        await unitOfWork.ReviewRepository.Create(review.CreateToReview());
        int res = unitOfWork.Complete();
        return res is 0
        ? Result<bool>.Success(true)
        : Result<bool>.Failure(Error.BadRequest());
    }

    public async Task<Result<bool>> Delete(int id)
    {
        Result<Review> review = await unitOfWork.ReviewRepository.GetById(id);
        if (review.Value is null)
            return Result<bool>.Failure(Error.NotFound());

        review.Value.ToDeleted();
        int res = unitOfWork.Complete();
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Failure(Error.BadRequest());
    }

    public async Task<Result<PaginationResponse<IEnumerable<ReadReviewInfo>>>> GetAll(BaseFilter filter)
    {
        Result<IEnumerable<Review>> reviews = await unitOfWork.ReviewRepository.GetAll(filter);

        if (reviews is null)
            return Result<PaginationResponse<IEnumerable<ReadReviewInfo>>>.Failure(Error.NotFound());

        IEnumerable<ReadReviewInfo> res = reviews.Value!
        .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x => x.ToRead())
            .ToList();

        int count = res.Count();

        PaginationResponse<IEnumerable<ReadReviewInfo>> response =
         PaginationResponse<IEnumerable<ReadReviewInfo>>.Create(filter.PageNumber, filter.PageSize, count, res);

        return Result<PaginationResponse<IEnumerable<ReadReviewInfo>>>.Success(response);
    }

    public async Task<Result<ReadReviewInfo>> GetById(int id)
    {
        Result<Review> result = await unitOfWork.ReviewRepository.GetById(id);
        if (result.Value is null)
            return Result<ReadReviewInfo>.Failure(Error.NotFound());

        if (result.Value.IsDeleted == false)
            return Result<ReadReviewInfo>.Success(result.Value.ToRead());
        return Result<ReadReviewInfo>.Failure(Error.NotFound());
    }

    public async Task<Result<bool>> Update(UpdateReviewInfo review)
    {
        Result<Review> reviewUpdate = await unitOfWork.ReviewRepository.GetById(review.Id);
        if (reviewUpdate.Value is null)
            return Result<bool>.Failure(Error.NotFound());

        reviewUpdate.Value.UpdateToReview(review);
        int res = unitOfWork.Complete();
        return res > 0
        ? Result<bool>.Failure(Error.BadRequest())
        : Result<bool>.Success(true);
    }
}