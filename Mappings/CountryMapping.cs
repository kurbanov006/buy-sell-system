public static class CountryMapping
{
    public static Country CreateCountryToCountry(this CreateCountryInfo countryInfo)
    {
        return new Country()
        {
            CountryName = countryInfo.CountryBaseInfo.CountryName
        };
    }

    public static Country UpdateCountryToCountry(this Country country, UpdateCountryInfo countryInfo)
    {
        country.UpdatedAt = DateTime.UtcNow;
        country.CountryName = countryInfo.CountryBaseInfo.CountryName;
        return country;
    }

    public static Country ToDelete(this Country country)
    {
        country.DeletedAt = DateTime.UtcNow;
        country.IsDeleted = true;
        return country;
    }

    public static ReadCountryInfo ToRead(this Country country)
    {
        return new ReadCountryInfo()
        {
            Id = country.Id,
            CreatedAt = country.CreatedAt,
            CountryBaseInfo = new()
            {
                CountryName = country.CountryName
            }
        };
    }
}