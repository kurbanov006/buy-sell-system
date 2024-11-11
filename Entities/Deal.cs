public class Deal : BaseEntity
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int SellerUserId { get; set; }
    public SellerUser? SellerUser { get; set; }
    public int CustomerUserId { get; set; }
    public CustomerUser? CustomerUser { get; set; }
}
// Сделкa