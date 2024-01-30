using CCore.Dtos;
using CCore.Entities;

namespace CCore.Interface;

public interface IBookRepository
{
    Task<List<BookDto>> GetBooksAsync(int pageNumber, int pageSize, Category filter);
    Task<BookDto> GetBookByIdAsync(int id);
    Task AddBookAsync(BookDto bookDto);
    Task UpdateBookAsync(int id, BookDto bookDto);
    Task DeleteBookAsync(int id);
}
