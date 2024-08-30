
namespace LinkEcommerce.Services.Catalogs.Data;

public class CatalogDbContext : DbContext
{
     public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }

    public DbSet<CatalogBrand> Brands { get; set; }
    public DbSet<CatalogItem> CatalogItems { get; set; }
    public DbSet<CatalogType> IdentificationTypes { get; set; }

    /// <summary>
    /// On model creating database, and specific change model
    /// </summary>
    /// <param name="modelBuilder">Model builder application</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<UserApplication>().HasIndex(u => new { u.User.TypeIdentificationId, u.User.Identification }).IsUnique();
        modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
    }
}