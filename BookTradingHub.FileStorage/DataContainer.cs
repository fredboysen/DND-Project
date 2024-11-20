using BookTradingHub.Domain.Models;

namespace BookTradingHub.FileStorage;

public record DataContainer
{
    public List<User> Users { get; set; } = [];
    public List<Todo> Todos { get; set; } = [];
}
