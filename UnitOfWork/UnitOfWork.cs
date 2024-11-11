public class UnitOfWork<T> : IUnitOfWork<T> where T : BaseEntity
{
    private readonly AppDbContext _appDbContext;
    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        Country = new CountryRepository(_appDbContext);
        City = new CityRepository(_appDbContext);
        SellerUserRepository = new SellerUserRepository(_appDbContext);
        CustomerUserRepository = new CustomerUserRepository(_appDbContext);
        ProductRepository = new ProductRepository(_appDbContext);
        DealRepository = new DealRepository(_appDbContext);
        ReviewRepository = new ReviewRepository(_appDbContext);
    }
    public ICountryRepository Country { get; private set; }
    public ICityRepositoty City { get; private set; }
    public ISellerUserRepository SellerUserRepository { get; private set; }
    public ICustomerUserRepository CustomerUserRepository { get; private set; }
    public IProductRepository ProductRepository { get; private set; }
    public IDealRepository DealRepository { get; private set; }
    public IReviewRepository ReviewRepository { get; private set; }

    public int Complete()
    {
        int res = _appDbContext.SaveChanges();
        return res;
    }

    public void Dispose()
    {
        _appDbContext.DisposeAsync();
    }
}