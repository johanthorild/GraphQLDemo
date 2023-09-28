using GraphQLDemo.Data;
using GraphQLDemo.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Queries;

public class TeamQuery
{
    public async Task<TeamType?> GetTeamById(
        ClubContext context,
        Guid id)
        => await context.Teams
            .Include(t => t.Players)
            .FirstOrDefaultAsync(t => t.Id == id);

    public IQueryable<TeamType> GetTeams(ClubContext context)
        => context.Teams.OrderBy(t => t.Name);
}