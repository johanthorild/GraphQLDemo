namespace GraphQLDemo.Schema;

public class TeamType
{
    public Guid Id { get; init; }
    public string? Name { get; init; }

    public IEnumerable<PlayerType>? Players { get; set; }
}