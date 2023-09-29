namespace GraphQLDemo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.
    }

        public static IServiceCollection AddPersistance(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ClubContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("ClubDatabase"));
        });

        services.AddScoped<IClubContext, ClubContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}