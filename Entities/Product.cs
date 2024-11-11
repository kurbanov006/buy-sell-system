public class Product : BaseEntity
{
    public string ProductName { get; set; } = string.Empty;
    public int SellerUserId { get; set; }
    public SellerUser? SellerUser { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}