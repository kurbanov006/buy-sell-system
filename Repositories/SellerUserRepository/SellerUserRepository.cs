public class SellerUserRepository : GenericRepository<SellerUser>, ISellerUserRepository
{
    public SellerUserRepository(AppDbContext context) : base(context)
    {
    }
}