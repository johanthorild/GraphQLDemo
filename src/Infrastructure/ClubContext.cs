namespace GraphQLDemo.Infrastructure;

public class ClubContext : DbContext
{
    public ClubContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TeamType> Teams => Set<TeamType>();
    public DbSet<PlayerType> Players => Set<PlayerType>();
    public DbSet<FixtureType> Fixtures => Set<FixtureType>();
    public DbSet<ResultType> Results => Set<ResultType>();
    public DbSet<ArticleType> Articles => Set<ArticleType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<TeamType>()
            .HasMany(t => t.Players)
            .WithOne(p => p.Team)
            .HasForeignKey(p => p.TeamId)
            .OnDelete(DeleteBehavior.SetNull);

        base.OnModelCreating(modelBuilder);

        SeedInitialData(modelBuilder);
    }

    private static void SeedInitialData(ModelBuilder modelBuilder)
    {
        // Add initial data if needed
    }

}