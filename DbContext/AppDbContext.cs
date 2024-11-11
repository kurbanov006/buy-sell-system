using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<SellerUser> SellerUsers { get; set; }
    public DbSet<CustomerUser> CustomerUsers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Deal> Desls { get; set; }
    public DbSet<Review> Reviews { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}