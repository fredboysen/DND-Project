using BookTradingHub.Domain.Models;

namespace BookTradingHub.FileStorage;

public record DataContainer
{
    public List<User> Users { get; set; } = [];
    public List<Books> Books { get; set; } = [];
}
