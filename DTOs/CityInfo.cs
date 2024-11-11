public readonly record struct CityBaseInfo(
    string CityName,
    int CountryId
);

public readonly record struct CreateCityInfo(
    CityBaseInfo CityBaseInfo
);

public readonly record struct UpdateCityInfo(
    int Id,
    CityBaseInfo CityBaseInfo
);

public readonly record struct ReadCityInfo(
    int Id,
    CityBaseInfo CityBaseInfo,
    DateTime CreatedAt
);