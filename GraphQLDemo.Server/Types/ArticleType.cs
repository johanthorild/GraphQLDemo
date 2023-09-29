using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Server.Types;

[Index(nameof(Id))]
public class ArticleType
{
    public ArticleType() { }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [MaxLength(50)]
    [Required]
    public string Title { get; init; } = null!;
    
    [Required]
    public string Content { get; init; } = null!;

    public DateTime Publicated { get; init; } = default!;

    [MaxLength(50)]
    [Required]
    public string Author { get; init;} = null!;
}