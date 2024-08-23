using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservice.Book.Api.Domain;

[Table("MSOS_Author")]
public class Author
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(30)]
    [Required]
    public string Surname { get; set; } = string.Empty;

    [MaxLength(30)]
    [Required]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(30)]
    public string? MiddleName { get; set; }
}
