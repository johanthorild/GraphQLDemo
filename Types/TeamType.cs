namespace GraphQLDemo.Types;

public class TeamType
{
    public TeamType() { }

    public TeamType(
        string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public Guid Id { get; init; }
    public string? Name { get; init; }

    public IEnumerable<PlayerType>? Players { get; set; }
}