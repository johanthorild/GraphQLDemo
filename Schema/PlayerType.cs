namespace GraphQLDemo.Schema;

public enum Position
{
    Goalkeeper = 1,
    Defender = 2,
    Midfielder = 3,
    Forward = 4,
}

public class PlayerType
{
    public Guid Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public Position? Position { get; init; }
    public int? ShirtNumber { get; init; }
    public TeamType? Team { get; set; } 
    public string? TeamName => Team?.Name;
}