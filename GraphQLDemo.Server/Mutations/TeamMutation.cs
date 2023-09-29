using GraphQLDemo.Server.Common.Enums;
using GraphQLDemo.Server.Data;
using GraphQLDemo.Server.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Server.Mutations;

public class TeamMutation
{
    public async Task<Guid> CreateTeam(
        ClubContext context,
        string name)
    {
        if (await context.Teams.AnyAsync(t => t.Name == name))
        {
            throw new Exception($"Team with same name already exists");
        }

        var result = await context.Teams.AddAsync(
            new TeamType(name));
        await context.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<bool> CreateStandardTeams(ClubContext context) 
    {
        if (await context.Teams.AnyAsync(t =>
            t.Id == TeamStandard.MensTeamId ||
            t.Id == TeamStandard.WomensTeamId ||
            t.Id == TeamStandard.YouthsTeamId))
        {
            throw new Exception("Standard teams are already created");
        }

        var teamsToAdd = new List<TeamType>
        {
            new (TeamStandard.MensTeamId, TeamStandard.MensTeamName),
            new (TeamStandard.WomensTeamId, TeamStandard.WomensTeamName),
            new (TeamStandard.YouthsTeamId, TeamStandard.YouthsTeamName)
        };

        await context.Teams.AddRangeAsync(teamsToAdd);
        var result = await context.SaveChangesAsync();

        return result != 0;
    }
}