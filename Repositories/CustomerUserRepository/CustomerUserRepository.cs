public class CustomerUserRepository : GenericRepository<CustomerUser>, ICustomerUserRepository
{
    public CustomerUserRepository(AppDbContext context) : base(context)
    {
    }
}