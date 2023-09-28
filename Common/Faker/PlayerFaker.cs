using Bogus;
using GraphQLDemo.Types;
using GraphQLDemo.Common.Extensions;
using GraphQLDemo.Common.Enums;

namespace GraphQLDemo.Common.Faker;

public class PlayerFaker
{
    public static IEnumerable<PlayerType> FakePlayers(int amount, Guid teamId)
        => new Faker<PlayerType>()
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.FirstName, (f, p) =>
            {
                if (teamId == TeamStandard.MensTeamId)
                    return f.Name.FirstName(Bogus.DataSets.Name.Gender.Male);
                else if (teamId == TeamStandard.WomensTeamId)
                    return f.Name.FirstName(Bogus.DataSets.Name.Gender.Female);
                else
                    return f.Name.FirstName();
            })
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.ShirtNumber, f => f.Random.Int(1, 30))
            .RuleFor(p => p.Position, f => EnumExtensions.PickRandomEnumValue<PlayerPosition>())
            .RuleFor(p => p.TeamId, teamId)
            .Generate(amount);
}