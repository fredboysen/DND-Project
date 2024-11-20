using System.Diagnostics.Metrics;
using BookTradingHub.Application.Interfaces;
using BookTradingHub.Domain.Models;

namespace BookTradingHub.FileStorage;

public class FileUserService(FileContext context) : IUserService
{
    private readonly FileContext context = context;

    public List<User> GetUsers()
    {
        return [.. context.Users];
    }

    public async Task<User> SaveUserAsync(User user)
    {
        user.Id = context.Users.Select(user => user.Id).DefaultIfEmpty().Max() + 1;
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user;
    }
}
