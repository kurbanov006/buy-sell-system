using Microsoft.EntityFrameworkCore;

public static class Register
{
    public static void RegisterService(this IServiceCollection services)
    {
        services.AddTransient<ICountryService, CountryService>();
        services.AddTransient<ICityService, CityService>();
        services.AddTransient<ISellerUserService, SellerUserService>();
        services.AddTransient<ICustomerUserService, CustomerUserService>();
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<IDealService, DealService>();
        services.AddTransient<IReviewService, ReviewService>();
    }
    public static void RegisterRepository(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddTransient<ICountryRepository, CountryRepository>();
        services.AddTransient<ICityRepositoty, CityRepository>();
        services.AddTransient<ISellerUserRepository, SellerUserRepository>();
        services.AddTransient<ICustomerUserRepository, CustomerUserRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IDealRepository, DealRepository>();
        services.AddTransient<IReviewRepository, ReviewRepository>();

        services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
    }
}