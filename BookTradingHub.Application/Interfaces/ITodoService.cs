using BookTradingHub.Domain.Models;

namespace BookTradingHub.Application.Interfaces;

public interface ITodoService
{
    public List<Todo> GetTodos();
    Task RemoveTodoAsync(int id);
    public Task<Todo> SaveTodoAsync(Todo todo);
    Task UpdateTodoAsync(Todo todo);
}
