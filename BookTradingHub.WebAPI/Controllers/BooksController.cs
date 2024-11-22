using BookTradingHub.Application.Interfaces;
using BookTradingHub.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookTradingHub.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BooksController(IBookService bookService) : ControllerBase
    {
        /// <summary>
        /// Retrieves all book listings.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return bookService.GetBooks();
        }

        /// <summary>
        /// Saves a new book listing.
        /// </summary>
        [HttpPost(Name = "SaveBook")]
        public async Task<ActionResult> SaveBookAsync(Book book)
        {
            await bookService.SaveBookAsync(book);
            return CreatedAtAction("SaveBook", book);
        }

        /// <summary>
        /// Updates an existing book listing by ID.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBookAsync(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            await bookService.UpdateBookAsync(book);
            return NoContent();
        }

        /// <summary>
        /// Removes a book listing by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveBookAsync(int id)
        {
            await bookService.RemoveBookAsync(id);
            return NoContent();
        }
    }
}
