

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

public class CountryService(IUnitOfWork<Country> unitOfWork) : ICountryService
{
    public async Task<Result<bool>> Create(CreateCountryInfo country)
    {
        await unitOfWork.Country.Create(country.CreateCountryToCountry());
        int res = unitOfWork.Complete();
        return res is 0
        ? Result<bool>.Success(true)
        : Result<bool>.Failure(Error.BadRequest());
    }

    public async Task<Result<bool>> Delete(int id)
    {
        Result<Country> country = await unitOfWork.Country.GetById(id);
        if (country.Value is null)
            return Result<bool>.Failure(Error.NotFound());

        country.Value.ToDelete();
        int res = unitOfWork.Complete();
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Failure(Error.BadRequest());
    }

    public async Task<Result<PaginationResponse<IEnumerable<ReadCountryInfo>>>> GetAll(BaseFilter filter)
    {
        Result<IEnumerable<Country>> countries = await unitOfWork.Country.GetAll(filter);

        if (countries is null)
            return Result<PaginationResponse<IEnumerable<ReadCountryInfo>>>.Failure(Error.NotFound());

        IEnumerable<ReadCountryInfo> res = countries.Value!
        .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x => x.ToRead())
            .ToList();

        int count = res.Count();

        PaginationResponse<IEnumerable<ReadCountryInfo>> response =
         PaginationResponse<IEnumerable<ReadCountryInfo>>.Create(filter.PageNumber, filter.PageSize, count, res);

        return Result<PaginationResponse<IEnumerable<ReadCountryInfo>>>.Success(response);
    }

    public async Task<Result<ReadCountryInfo>> GetById(int id)
    {
        Result<Country> result = await unitOfWork.Country.GetById(id);
        if (result.Value is null)
            return Result<ReadCountryInfo>.Failure(Error.NotFound());

        if (result.Value.IsDeleted == false)
            return Result<ReadCountryInfo>.Success(result.Value.ToRead());
        return Result<ReadCountryInfo>.Failure(Error.NotFound());
    }

    public async Task<Result<bool>> Update(UpdateCountryInfo value)
    {
        Result<Country> country = await unitOfWork.Country.GetById(value.Id);
        if (country.Value is null)
            return Result<bool>.Failure(Error.NotFound());

        country.Value.UpdateCountryToCountry(value);
        int res = unitOfWork.Complete();
        return res > 0
        ? Result<bool>.Failure(Error.BadRequest())
        : Result<bool>.Success(true);
    }
}