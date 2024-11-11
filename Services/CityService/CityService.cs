
public class CityService(IUnitOfWork<City> unitOfWork) : ICityService
{
    public async Task<Result<bool>> Create(CreateCityInfo city)
    {
        await unitOfWork.City.Create(city.CreateToCity());
        int res = unitOfWork.Complete();
        return res is 0
        ? Result<bool>.Success(true)
        : Result<bool>.Failure(Error.BadRequest());
    }

    public async Task<Result<bool>> Delete(int id)
    {
        Result<City> result = await unitOfWork.City.GetById(id);
        if (result.Value is null)
            return Result<bool>.Failure(Error.NotFound());

        result.Value.ToDeleted();
        int res = unitOfWork.Complete();
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Failure(Error.BadRequest());
    }

    public async Task<Result<PaginationResponse<IEnumerable<ReadCityInfo>>>> GetAll(BaseFilter filter)
    {
        Result<IEnumerable<City>> cities = await unitOfWork.City.GetAll(filter);

        if (cities is null)
            return Result<PaginationResponse<IEnumerable<ReadCityInfo>>>.Failure(Error.NotFound());

        IEnumerable<ReadCityInfo> res = cities.Value!
        .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x => x.ToRead())
            .ToList();

        int count = res.Count();

        PaginationResponse<IEnumerable<ReadCityInfo>> response =
         PaginationResponse<IEnumerable<ReadCityInfo>>.Create(filter.PageNumber, filter.PageSize, count, res);

        return Result<PaginationResponse<IEnumerable<ReadCityInfo>>>.Success(response);
    }

    public async Task<Result<ReadCityInfo>> GetById(int id)
    {
        Result<City> result = await unitOfWork.City.GetById(id);
        if (result.Value is null)
            return Result<ReadCityInfo>.Failure(Error.NotFound());

        if (result.Value.IsDeleted == false)
            return Result<ReadCityInfo>.Success(result.Value.ToRead());
        return Result<ReadCityInfo>.Failure(Error.NotFound());
    }

    public async Task<Result<bool>> Update(UpdateCityInfo city)
    {
        Result<City> cityUpdate = await unitOfWork.City.GetById(city.Id);
        if (cityUpdate.Value is null)
            return Result<bool>.Failure(Error.NotFound());

        cityUpdate.Value.UpdateCityToCity(city);
        int res = unitOfWork.Complete();
        return res > 0
        ? Result<bool>.Failure(Error.BadRequest())
        : Result<bool>.Success(true);
    }
}