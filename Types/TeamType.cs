using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Types;

[Index(nameof(Id))]
public class TeamType
{
    public TeamType() { }

    public TeamType(
        Guid id,
        string name)
    {
        Id = id;
        Name = name;
    }

    public TeamType(
        string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    [Key]
    public Guid Id { get; init; }

    [MaxLength(50)]
    public string? Name { get; init; }

    public IEnumerable<PlayerType>? Players { get; set; }
}