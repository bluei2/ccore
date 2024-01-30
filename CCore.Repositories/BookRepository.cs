using AutoMapper;
using CCore.Dtos;
using CCore.Entities;
using CCore.Interface;
using Microsoft.EntityFrameworkCore;

namespace CCore.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _context;
    private readonly IMapper _mapper;

    public BookRepository(LibraryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<BookDto>> GetBooksAsync(int pageNumber, int pageSize, Category filter)
    {
        var books = _context.Set<Category>()
            .Where(x =>
            (filter.Name == null || x.Name.Contains(filter.Name))
            )
            .Include(x=> x.Name)
            .Include(x=> x.Books)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var bookList = _mapper.Map<List<BookDto>>(books);
        return bookList;
    }

    public async Task<BookDto> GetBookByIdAsync(int id)
    {
        var book = _context.Books
            .Include(x=>x.Category)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        var bookDto = _mapper.Map<BookDto>(book);
        return bookDto;
    }

    public async Task AddBookAsync(BookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);

         _context.Books.Add(book);
         await _context.SaveChangesAsync();
    }

    public async Task UpdateBookAsync(int id, BookDto bookDto)
    {
        var book = _context.Books.SingleOrDefault(x => x.Id == id);

        _context.Entry(book).CurrentValues.SetValues(bookDto);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = _context.Books.SingleOrDefault(x => x.Id == id);

        _context.Remove(book);
        await _context.SaveChangesAsync();
    }
}

