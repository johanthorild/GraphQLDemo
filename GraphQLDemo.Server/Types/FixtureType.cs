using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Server.Types;

[Index(nameof(Id))]
public class FixtureType
{
    public FixtureType() { }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [MaxLength(50)]
    [Required]
    public string HomeTeamName { get; init; } = null!;

    [MaxLength(50)]
    [Required]
    public string AwayTeamName { get; init; } = null!;

    public DateTime? Kickoff { get; init; }

    public string? Location { get; init; }

    public Guid? ArticleId { get; init; }

    public ArticleType? Article { get; set; }
}