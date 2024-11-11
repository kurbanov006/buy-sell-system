public class Review : BaseEntity
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int CustomerUserId { get; set; }
    public CustomerUser? CustomerUser { get; set; }
    public string? Comment { get; set; }
}