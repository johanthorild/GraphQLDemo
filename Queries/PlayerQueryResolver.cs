using GraphQLDemo.Common.Faker;
using GraphQLDemo.Data;
using GraphQLDemo.Types;

namespace GraphQLDemo.Queries;

[QueryType()]
public class PlayerQueryResolver
{
    public IQueryable<PlayerType> GetPlayers(ClubContext context)
        => context.Players.OrderBy(p => p.ShirtNumber);
}