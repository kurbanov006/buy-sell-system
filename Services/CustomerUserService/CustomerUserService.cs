
public class CustomerUserService(IUnitOfWork<Country> unitOfWork) : ICustomerUserService
{
    public async Task<Result<bool>> Create(CreateCustomerUserInfo customerUser)
    {
        await unitOfWork.CustomerUserRepository.Create(customerUser.CreateToCustomerUser());
        int res = unitOfWork.Complete();
        return res is 0
        ? Result<bool>.Success(true)
        : Result<bool>.Failure(Error.BadRequest());
    }

    public async Task<Result<bool>> Delete(int id)
    {
        Result<CustomerUser> customer = await unitOfWork.CustomerUserRepository.GetById(id);
        if (customer.Value is null)
            return Result<bool>.Failure(Error.NotFound());

        customer.Value.ToDeleted();
        int res = unitOfWork.Complete();
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Failure(Error.BadRequest());
    }

    public async Task<Result<PaginationResponse<IEnumerable<ReadCustomerUserInfo>>>> GetAll(BaseFilter filter)
    {
        Result<IEnumerable<CustomerUser>> customers = await unitOfWork.CustomerUserRepository.GetAll(filter);

        if (customers is null)
            return Result<PaginationResponse<IEnumerable<ReadCustomerUserInfo>>>.Failure(Error.NotFound());

        IEnumerable<ReadCustomerUserInfo> res = customers.Value!
        .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x => x.ToRead())
            .ToList();

        int count = res.Count();

        PaginationResponse<IEnumerable<ReadCustomerUserInfo>> response =
         PaginationResponse<IEnumerable<ReadCustomerUserInfo>>.Create(filter.PageNumber, filter.PageSize, count, res);

        return Result<PaginationResponse<IEnumerable<ReadCustomerUserInfo>>>.Success(response);
    }

    public async Task<Result<ReadCustomerUserInfo>> GetById(int id)
    {
        Result<CustomerUser> result = await unitOfWork.CustomerUserRepository.GetById(id);
        if (result.Value is null)
            return Result<ReadCustomerUserInfo>.Failure(Error.NotFound());

        if (result.Value.IsDeleted == false)
            return Result<ReadCustomerUserInfo>.Success(result.Value.ToRead());
        return Result<ReadCustomerUserInfo>.Failure(Error.NotFound());
    }

    public async Task<Result<bool>> Update(UpdateCustomerUserInfo customerUser)
    {
        Result<CustomerUser> country = await unitOfWork.CustomerUserRepository.GetById(customerUser.Id);
        if (country.Value is null)
            return Result<bool>.Failure(Error.NotFound());

        country.Value.UpdateToSellerUser(customerUser);
        int res = unitOfWork.Complete();
        return res > 0
        ? Result<bool>.Failure(Error.BadRequest())
        : Result<bool>.Success(true);
    }
}