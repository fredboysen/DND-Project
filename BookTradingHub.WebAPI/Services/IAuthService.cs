using DNDProject.Domain.Models;

namespace DNDProject.WebAPI.Services;
public interface IAuthService
{
    Task<User> ValidateUser(string username, string password);
    Task RegisterUser(User user);
}
