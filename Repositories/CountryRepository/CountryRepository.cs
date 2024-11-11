public class CountryRepository : GenericRepository<Country>, ICountryRepository
{
    public CountryRepository(AppDbContext context) : base(context)
    {
    }
}