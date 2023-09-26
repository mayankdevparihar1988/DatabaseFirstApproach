
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace dbFirstApi.Models;

[PrimaryKey("AuthorId", "BookId")]
[Table("BookAuthor")]
public partial class BookAuthor
{
    [Key]
    [Column("author_id")]
    public int AuthorId { get; set; }

    [Key]
    [Column("book_id")]
    public int BookId { get; set; }

    [Column("author_order")]
    public byte? AuthorOrder { get; set; }

    [Column("royality_percentage")]
    public int? RoyalityPercentage { get; set; }

    [JsonIgnore]
    [ForeignKey("AuthorId")]
    [InverseProperty("BookAuthors")]
    public virtual Author Author { get; set; } = null!;

    [ForeignKey("BookId")]
    [InverseProperty("BookAuthors")]
    public virtual Book Book { get; set; } = null!;
}
