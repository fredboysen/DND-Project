using System.Diagnostics.Metrics;
using BookTradingHub.Application.Interfaces;
using BookTradingHub.Domain.Models;

namespace BookTradingHub.FileStorage;

public class FileBookService(FileContext context) : IBookService
{
    private readonly FileContext context = context;

    /// <summary>
    /// Retrieves all book listings.
    /// </summary>
    public List<Book> GetBooks()
    {
        return [...context.Books];
    }

    /// <summary>
    /// Removes a book listing by its ID.
    /// </summary>
    public async Task RemoveBookAsync(int id)
    {
        var book = context.Books.First(book => book.Id == id);
        context.Books.Remove(book);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Saves a new book listing.
    /// </summary>
    public async Task<Book> SaveBookAsync(Book book)
    {
        book.Id = context.Books.Select(book => book.Id).DefaultIfEmpty().Max() + 1;
        context.Books.Add(book);
        await context.SaveChangesAsync();
        return book;
    }

    /// <summary>
    /// Updates an existing book listing.
    /// </summary>
    public async Task UpdateBookAsync(Book book)
    {
        var indexToUpdate = context.Books.FindIndex(b => b.Id == book.Id);
        if (indexToUpdate != -1)
        {
            context.Books[indexToUpdate] = book;
            await context.SaveChangesAsync();
        }
    }
}
