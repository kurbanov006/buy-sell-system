using System.Linq;

public class SellerUserService(IUnitOfWork<SellerUser> unitOfWork) : ISellerUserService
{
    public async Task<Result<bool>> Create(CreateSellerUserInfo createSeller)
    {
        await unitOfWork.SellerUserRepository.Create(createSeller.CreateToSellerUser());
        int res = unitOfWork.Complete();
        return res is 0
        ? Result<bool>.Success(true)
        : Result<bool>.Failure(Error.BadRequest());
    }

    public async Task<Result<bool>> Delete(int id)
    {
        Result<SellerUser> sellerUser = await unitOfWork.SellerUserRepository.GetById(id);
        if (sellerUser.Value is null)
            return Result<bool>.Failure(Error.NotFound());

        sellerUser.Value.ToDeleted();
        int res = unitOfWork.Complete();
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Failure(Error.BadRequest());
    }

    public async Task<Result<PaginationResponse<IEnumerable<ReadSellerUserInfo>>>> GetAll(BaseFilter filter)
    {
        Result<IEnumerable<SellerUser>> sellerUsers = await unitOfWork.SellerUserRepository.GetAll(filter);

        if (sellerUsers is null)
            return Result<PaginationResponse<IEnumerable<ReadSellerUserInfo>>>.Failure(Error.NotFound());

        IEnumerable<ReadSellerUserInfo> res = sellerUsers.Value!
        .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x => x.ToRead())
            .ToList();

        int count = res.Count();

        PaginationResponse<IEnumerable<ReadSellerUserInfo>> response =
         PaginationResponse<IEnumerable<ReadSellerUserInfo>>.Create(filter.PageNumber, filter.PageSize, count, res);

        return Result<PaginationResponse<IEnumerable<ReadSellerUserInfo>>>.Success(response);
    }

    public async Task<Result<ReadSellerUserInfo>> GetById(int id)
    {
        Result<SellerUser> result = await unitOfWork.SellerUserRepository.GetById(id);
        if (result.Value is null)
            return Result<ReadSellerUserInfo>.Failure(Error.NotFound());

        if (result.Value.IsDeleted == false)
            return Result<ReadSellerUserInfo>.Success(result.Value.ToRead());
        return Result<ReadSellerUserInfo>.Failure(Error.NotFound());
    }

    // public async Task<GetSellerAndProducts> GetByIdSellerAndProducts(int id)
    // {
    //     IQueryable<GetSellerAndProducts> res = unitOfWork.SellerUserRepository.GetById(id).w
    // }

    public async Task<Result<bool>> Update(UpdateSellerUserInfo updateSeller)
    {
        Result<SellerUser> sellerUser = await unitOfWork.SellerUserRepository.GetById(updateSeller.Id);
        if (sellerUser.Value is null)
            return Result<bool>.Failure(Error.NotFound());

        sellerUser.Value.UpdateToSellerUser(updateSeller);
        int res = unitOfWork.Complete();
        return res > 0
        ? Result<bool>.Failure(Error.BadRequest())
        : Result<bool>.Success(true);
    }
}