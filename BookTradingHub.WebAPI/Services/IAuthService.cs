using BookTradingHub.Domain.Models;

namespace BookTradingHub.WebAPI.Services;
public interface IAuthService
{
    Task<User> ValidateUser(string username, string password);
    Task RegisterUser(User user);
}
