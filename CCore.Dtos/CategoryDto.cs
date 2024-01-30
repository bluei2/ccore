using System;
using CCore.Entities;

namespace CCore.Dtos;
public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<BookDto> Books { get; set; }
}

