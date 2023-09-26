using Bogus;
using GraphQLDemo.Types;
using GraphQLDemo.Common.Extensions;

namespace GraphQLDemo.Common.Faker;

public class TeamFaker
{
    public enum TeamFakeNames
    {
        Men = 1,
        Women = 2,
        Youth = 3
    };

    public static IEnumerable<TeamType> FakeTeams()
        => new Faker<TeamType>()
            .RuleFor(t => t.Id, f => Guid.NewGuid())
            .RuleFor(t => t.Name, f => f.PickRandom<TeamFakeNames>().ToString())
            // .RuleFor(t => t.Name, f =>
            //     Enum.GetValues(typeof(TeamFakeNames)).Cast<TeamFakeNames>()
            //     .ToString()
            //     .ToList()
            //     .PopRandom())
            .Generate(3);
}