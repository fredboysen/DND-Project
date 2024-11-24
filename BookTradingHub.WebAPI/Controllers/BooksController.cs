using BookTradingHub.Application.Interfaces;
using BookTradingHub.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookTradingHub.WebAPI.Controllers
[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService bookService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetBooks() => bookService.GetBooks();

    [HttpPost]
    public async Task<ActionResult> SaveBookAsync(Book book)
    {
        await bookService.SaveBookAsync(book);
        return CreatedAtAction("SaveBook", book);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBookAsync(int id, Book book)
    {
        if (id != book.Id) return BadRequest();
        await bookService.UpdateBookAsync(book);
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> RemoveBookAsync(int id)
    {
        await bookService.RemoveBookAsync(id);
        return NoContent();
    }
}
