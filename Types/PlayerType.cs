using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GraphQLDemo.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Types;

[Index(nameof(Id))]
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
        FirstName = firstName;
        LastName = lastName;
        Position = position;
        ShirtNumber = shirtNumber;
        TeamId = teamId;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [MaxLength(50)]
    public string? FirstName { get; init; }

    [MaxLength(50)]
    public string? LastName { get; init; }

    public PlayerPosition? Position { get; init; }

    public int? ShirtNumber { get; init; }
 
    public Guid TeamId { get; init; }

    public TeamType? Team { get; init; } 
}