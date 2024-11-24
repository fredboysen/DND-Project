using BookTradingHub.Domain.Models;

namespace BookTradingHub.Application.Interfaces;

public interface IBookService
{
    List<Book> GetBooks();
    Task RemoveBookAsync(int id);
    Task<Book> SaveBookAsync(Book book);
    Task UpdateBookAsync(Book book);
}

