public class DealRepository : GenericRepository<Deal>, IDealRepository
{
    public DealRepository(AppDbContext context) : base(context)
    {
    }
}