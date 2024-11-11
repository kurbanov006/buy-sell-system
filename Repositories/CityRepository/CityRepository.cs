public class CityRepository : GenericRepository<City>, ICityRepositoty
{
    public CityRepository(AppDbContext context) : base(context)
    {
    }
}