using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservice.Book.Api.Domain;

[Table("MSOS_Book")]
public class Book
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(150)]
    [Required]
    public string Title { get; set; }

    [MaxLength(13)]
    public string ISBN { get; set; }

    [ForeignKey("Id")]
    [Required]
    public Guid AuthorId { get; set; }
    public Author Author {get; set; }

    [ForeignKey("Id")]
    public int? PublisherId { get; set; }
    public Publisher Publisher { get; set; }

    [ForeignKey("Id")]
    public int? SeriesId { get; set; }
    public Series Series { get; set; }
     
    [MaxLength(2000)] 
    public string Summary { get; set; }

    [MaxLength(10)]
    [Required]
    public string Condition { get; set; }

    public int? NumberInStock { get; set; }

    [Column(TypeName = "decimal(19, 2)")]
    public decimal? Price { get; set; }

    [Column(TypeName = "decimal(19, 2)")]
    public decimal? Discount { get; set; }

    [ForeignKey("Id")]
    public int? DiscountTypeId { get; set; }
    public DiscountType DiscountType { get; set; }

    [Required]
    public DateTime Created { get; set; } = DateTime.Now;

    [Required]
    public DateTime LastUpdated { get; set; } = DateTime.Now;
}