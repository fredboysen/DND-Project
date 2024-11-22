using BookTradingHub.Domain.Models;

namespace BookTradingHub.Application.Interfaces;

public interface IBookService
{
    /// <summary>
    /// Retrieves all book listings.
    /// </summary>
    public List<Book> GetBooks();

    /// <summary>
    /// Removes a book listing by its ID.
    /// </summary>
    Task RemoveBookAsync(int id);

    /// <summary>
    /// Saves a new book listing.
    /// </summary>
    public Task<Book> SaveBookAsync(Book book);

    /// <summary>
    /// Updates an existing book listing.
    /// </summary>
    Task UpdateBookAsync(Book book);
}
