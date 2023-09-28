using GraphQLDemo.Common.Faker;
using GraphQLDemo.Data;
using GraphQLDemo.Types;

namespace GraphQLDemo.Queries;

[QueryType()]
public class TeamQueryResolver
{
    public IQueryable<TeamType> GetTeams(ClubContext context)
        => context.Teams.OrderBy(t => t.Name);
}