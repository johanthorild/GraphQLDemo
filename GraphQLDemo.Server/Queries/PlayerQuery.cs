using GraphQLDemo.Server.Data;
using GraphQLDemo.Server.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Server.Queries;

public class PlayerQuery
{
    public async Task<PlayerType?> GetPlayerById(
        ClubContext context,
        Guid id)
        => await context.Players
            .Include(p => p.Team)
            .FirstOrDefaultAsync(p => p.Id == id);

    public IQueryable<PlayerType> GetPlayers(ClubContext context)
        => context.Players.OrderBy(p => p.ShirtNumber);
}