using Bogus;
using GraphQLDemo.Types;
using GraphQLDemo.Common.Extensions;
using GraphQLDemo.Common.Enums;

namespace GraphQLDemo.Common.Faker;

public class PlayerFaker
{
    public static IEnumerable<PlayerType> FakePlayers(int amount, TeamType team)
        => new Faker<PlayerType>()
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.FirstName, (f, p) =>
            {
                if (team.Name == TeamFaker.TeamFakeNames.Men.ToString())
                    return f.Name.FirstName(Bogus.DataSets.Name.Gender.Male);
                else if (team.Name == TeamFaker.TeamFakeNames.Women.ToString())
                    return f.Name.FirstName(Bogus.DataSets.Name.Gender.Female);
                else
                    return f.Name.FirstName();
            })
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.ShirtNumber, f => f.Random.Int(1, 30))
            .RuleFor(p => p.Position, f => EnumExtensions.PickRandomEnumValue<PlayerPosition>())
            .RuleFor(p => p.Team, team)
            .Generate(amount);
}