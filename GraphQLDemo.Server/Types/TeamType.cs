using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Server.Types;

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
        Name = name;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [MaxLength(50)]
    public string? Name { get; init; }

    public IEnumerable<PlayerType>? Players { get; set; }
}