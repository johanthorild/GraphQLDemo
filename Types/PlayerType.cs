using GraphQLDemo.Common.Enums;

namespace GraphQLDemo.Types;

public class PlayerType
{
    public PlayerType() { }

    public PlayerType(
        string firstName,
        string lastName,
        PlayerPosition? position,
        int shirtNumber,
        Guid teamId)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Position = position;
        ShirtNumber = shirtNumber;
        TeamId = teamId;
    }

    public Guid Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public PlayerPosition? Position { get; init; }
    public int? ShirtNumber { get; init; }
    public Guid TeamId { get; init; }
    public TeamType? Team { get; init; } 
}