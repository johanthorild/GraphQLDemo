using Bogus;
using GraphQLDemo.Extensions;

namespace GraphQLDemo.Schema;

public class Query
{
    public IEnumerable<TeamType> GetTeams()
    {
        var teamNames = new List<string>
        {
            "Herrar",
            "Damer",
            "Ungdom"
        };

        var teamFaker = new Faker<TeamType>()
            .RuleFor(t => t.Id, f => Guid.NewGuid())
            .RuleFor(t => t.Name, f => teamNames.PopRandom());

        var teams = teamFaker.Generate(3);

        foreach(var team in teams)
        {
            var players = GeneratePlayers(team);
            team.Players = players;
        }

        return teams;
    }

    private static List<PlayerType> GeneratePlayers(TeamType team)
    {
        var playerFaker = new Faker<PlayerType>()
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.FirstName, (f, p) =>
            {
                if (team.Name == "Herrar")
                    return f.Name.FirstName(Bogus.DataSets.Name.Gender.Male);
                else if (team.Name == "Damer")
                    return f.Name.FirstName(Bogus.DataSets.Name.Gender.Female);
                else
                    return f.Name.FirstName();
            })
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.ShirtNumber, f => f.Random.Int(1, 30))
            .RuleFor(p => p.Position, f => f.PickRandom<Position>())
            .RuleFor(p => p.Team, team);

        return playerFaker.Generate(11);
    }
}