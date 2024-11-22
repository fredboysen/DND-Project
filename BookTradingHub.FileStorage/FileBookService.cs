public class FileBookService(FileContext context) : IBookService
{
    private readonly FileContext context = context;

    public List<Book> GetBooks() => context.Books;

    public async Task RemoveBookAsync(int id)
    {
        var book = context.Books.First(b => b.Id == id);
        context.Books.Remove(book);
        await context.SaveChangesAsync();
    }

    public async Task<Book> SaveBookAsync(Book book)
    {
        book.Id = context.Books.Select(b => b.Id).DefaultIfEmpty().Max() + 1;
        context.Books.Add(book);
        await context.SaveChangesAsync();
        return book;
    }

    public async Task UpdateBookAsync(Book book)
    {
        var indexToUpdate = context.Books.FindIndex(b => b.Id == book.Id);
        if (indexToUpdate != -1)
        {
            context.Books[indexToUpdate] = book;
            await context.SaveChangesAsync();
        }
    }

    public List<Book> GetAvailableBooks()
    {
        return context.Books.Where(b => b.IsAvailableForRental).ToList();
    }
}
