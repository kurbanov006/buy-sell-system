
public class DealService(IUnitOfWork<Deal> unitOfWork) : IDealService
{
    public async Task<Result<bool>> Create(CreateDealInfo deal)
    {
        await unitOfWork.DealRepository.Create(deal.CreateToDeal());
        int res = unitOfWork.Complete();
        return res is 0
        ? Result<bool>.Success(true)
        : Result<bool>.Failure(Error.BadRequest());
    }

    public async Task<Result<bool>> Delete(int id)
    {
        Result<Deal> product = await unitOfWork.DealRepository.GetById(id);
        if (product.Value is null)
            return Result<bool>.Failure(Error.NotFound());

        product.Value.ToDeleted();
        int res = unitOfWork.Complete();
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Failure(Error.BadRequest());
    }

    public async Task<Result<PaginationResponse<IEnumerable<ReadDealInfo>>>> GetAll(BaseFilter filter)
    {
        Result<IEnumerable<Deal>> deals = await unitOfWork.DealRepository.GetAll(filter);

        if (deals is null)
            return Result<PaginationResponse<IEnumerable<ReadDealInfo>>>.Failure(Error.NotFound());

        IEnumerable<ReadDealInfo> res = deals.Value!
        .Skip((filter.PageNumber - 1) * filter.PageSize)
        .Take(filter.PageSize)
        .Select(x => x.ToRead())
        .ToList();

        int count = res.Count();

        PaginationResponse<IEnumerable<ReadDealInfo>> response =
         PaginationResponse<IEnumerable<ReadDealInfo>>.Create(filter.PageNumber, filter.PageSize, count, res);

        return Result<PaginationResponse<IEnumerable<ReadDealInfo>>>.Success(response);
    }

    public async Task<Result<ReadDealInfo>> GetById(int id)
    {
        Result<Deal> result = await unitOfWork.DealRepository.GetById(id);
        if (result.Value is null)
            return Result<ReadDealInfo>.Failure(Error.NotFound());

        if (result.Value.IsDeleted == false)
            return Result<ReadDealInfo>.Success(result.Value.ToRead());
        return Result<ReadDealInfo>.Failure(Error.NotFound());
    }

    public async Task<Result<bool>> Update(UpdateDealInfo deal)
    {
        Result<Deal> dealUpdate = await unitOfWork.DealRepository.GetById(deal.Id);
        if (dealUpdate.Value is null)
            return Result<bool>.Failure(Error.NotFound());

        dealUpdate.Value.UpdateToDeal(deal);
        int res = unitOfWork.Complete();
        return res > 0
        ? Result<bool>.Failure(Error.BadRequest())
        : Result<bool>.Success(true);
    }
}