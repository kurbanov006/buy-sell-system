using Microsoft.AspNetCore.SignalR;

public interface IUnitOfWork<T> : IDisposable where T : BaseEntity
{
    ICountryRepository Country { get; }
    ICityRepositoty City { get; }
    ISellerUserRepository SellerUserRepository { get; }
    ICustomerUserRepository CustomerUserRepository { get; }
    IProductRepository ProductRepository { get; }
    IDealRepository DealRepository { get; }
    IReviewRepository ReviewRepository { get; }
    int Complete();
}