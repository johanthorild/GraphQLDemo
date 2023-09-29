using GraphQLDemo.Server.Types;
using GraphQLDemo.Server.Common.Enums;
using GraphQLDemo.Server.Common.Faker;
using GraphQLDemo.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Server.Mutations;

public class PlayerMutation
{
    public async Task<Guid> CreatePlayer(
        ClubContext context,
        string firstName,
        string lastName,
        PlayerPosition? position,
        int shirtNumber,
        Guid teamId)
    {
        if (await context.Players.AnyAsync(p =>
            p.FirstName == firstName &&
            p.LastName == lastName &&
            p.ShirtNumber == shirtNumber))
        {
            throw new Exception($"Player with same name and shirtnumber already exists");
        }
        var result = await context.Players.AddAsync(
            new PlayerType(firstName, lastName, position, shirtNumber, teamId));
        await context.SaveChangesAsync();
        return result.Entity.Id;
    }

    public async Task<bool> CreateFakePlayers(
        ClubContext context,
        int amount,
        Guid teamId)
    {
        await context.Players.AddRangeAsync(
            PlayerFaker.FakePlayers(amount, teamId));
        var result = await context.SaveChangesAsync();
        return result != 0;
    }
}