namespace LinkEcommerce.Services.Identity.Data;

public class IdentityAppDbContext : IdentityDbContext<UserApplication, UserType, Guid>
{
    public IdentityAppDbContext(DbContextOptions<IdentityAppDbContext> options) : base(options) { }

    public DbSet<Card> Cards { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<IdentificationType> IdentificationTypes { get; set; }

    /// <summary>
    /// On model creating database, and specific change model
    /// </summary>
    /// <param name="modelBuilder">Model builder application</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
    }
}