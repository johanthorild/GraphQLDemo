using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Server.Types;

[Index(nameof(Id))]
public class ResultType
{
    public ResultType() { }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [MaxLength(50)]
    [Required]
    public string HomeTeamName { get; init; } = null!;

    [MaxLength(50)]
    [Required]
    public string AwayTeamName { get; init; } = null!;

    public int HomeScore { get; init; } = default;

    public int AwayScore { get; init; } = default;

    public DateTime? Kickoff { get; init; }

    public string? Location { get; init; }

    public Guid? ArticleId { get; init; }

    public ArticleType? Article { get; set; }
}