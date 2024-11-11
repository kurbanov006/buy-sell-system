public readonly record struct CountryBaseInfo(
    string CountryName
);

public readonly record struct CreateCountryInfo(
    CountryBaseInfo CountryBaseInfo
);

public readonly record struct UpdateCountryInfo(
    int Id,
    CountryBaseInfo CountryBaseInfo
);

public readonly record struct ReadCountryInfo(
    int Id,
    CountryBaseInfo CountryBaseInfo,
    DateTime CreatedAt
);

