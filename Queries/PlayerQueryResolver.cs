using GraphQLDemo.Common.Faker;
using GraphQLDemo.Types;

namespace GraphQLDemo.Queries;

[ExtendObjectType("Query")]
public class PlayerQueryResolver
{
    public IEnumerable<PlayerType> GetPlayers()
    {
        var teams = TeamFaker.FakeTeams();
        teams
        .ToList()
        .ForEach(t => t.Players = PlayerFaker.FakePlayers(11, t));
        return teams
            .SelectMany(t => t.Players!)
            .ToArray();
    }
}