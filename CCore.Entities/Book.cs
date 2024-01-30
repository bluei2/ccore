using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCore.Entities;

public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime PublishDateUtc { get; set; }
}

