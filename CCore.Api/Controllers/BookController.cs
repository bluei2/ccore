using CCore.Dtos;
using CCore.Entities;
using CCore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CCore.Api.Controllers;

[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BookController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks(int page, int pageSize, Category filter)
    {
        var books = await _bookRepository.GetBooksAsync(page, pageSize, filter);
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await _bookRepository.GetBookByIdAsync(id);
        if (book == null)
            return NotFound();

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] BookDto bookDto)
    {
        await _bookRepository.AddBookAsync(bookDto);
        return CreatedAtAction(nameof(GetBookById), new { id = bookDto.Id }, bookDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDto bookDto)
    {
        await _bookRepository.UpdateBookAsync(id, bookDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await _bookRepository.DeleteBookAsync(id);
        return NoContent();
    }
}

