using GraphQLDemo.Common.Enums;
using GraphQLDemo.Common.Faker;
using GraphQLDemo.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Data;

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
            .HasForeignKey(p => p.TeamId);

        base.OnModelCreating(modelBuilder);

        SeedFakeData(modelBuilder); // Enable in development
    }

    private static void SeedFakeData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TeamType>()
            .HasData(
                new TeamType(TeamStandard.MensTeamId, TeamStandard.MensTeamName),
                new TeamType(TeamStandard.WomensTeamId, TeamStandard.WomensTeamName),
                new TeamType(TeamStandard.YouthsTeamId, TeamStandard.YouthsTeamName)
            );

        modelBuilder.Entity<PlayerType>()
            .HasData(
                PlayerFaker.FakePlayers(11, TeamStandard.MensTeamId),
                PlayerFaker.FakePlayers(11, TeamStandard.WomensTeamId),
                PlayerFaker.FakePlayers(11, TeamStandard.YouthsTeamId)
            );
    }

}