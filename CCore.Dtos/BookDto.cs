using CCore.Entities;

namespace CCore.Dtos;

public class BookDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime PublishDateUtc { get; set; }
}



