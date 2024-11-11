using System.Diagnostics;

public static class CityMapping
{
    public static City CreateToCity(this CreateCityInfo createCityInfo)
    {
        return new City()
        {
            CityName = createCityInfo.CityBaseInfo.CityName,
            CountryId = createCityInfo.CityBaseInfo.CountryId
        };
    }

    public static City UpdateCityToCity(this City city, UpdateCityInfo updateCity)
    {
        city.CityName = updateCity.CityBaseInfo.CityName;
        city.CountryId = updateCity.CityBaseInfo.CountryId;
        city.UpdatedAt = DateTime.UtcNow;
        return city;
    }

    public static ReadCityInfo ToRead(this City city)
    {
        return new ReadCityInfo()
        {
            Id = city.Id,
            CityBaseInfo = new CityBaseInfo()
            {
                CityName = city.CityName,
                CountryId = city.CountryId
            }
        };
    }

    public static City ToDeleted(this City city)
    {
        city.DeletedAt = DateTime.UtcNow;
        city.IsDeleted = true;
        return city;
    }
}