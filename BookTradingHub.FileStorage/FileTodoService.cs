using System.Diagnostics.Metrics;
using BookTradingHub.Application.Interfaces;
using BookTradingHub.Domain.Models;

namespace BookTradingHub.FileStorage;

public class FileTodoService(FileContext context) : ITodoService
{
    private readonly FileContext context = context;

    public List<Todo> GetTodos()
    {
        return [.. context.Todos];
    }

    public async Task RemoveTodoAsync(int id)
    {
        var todo = context.Todos.First(todo => todo.Id == id);
        context.Todos.Remove(todo);
        await context.SaveChangesAsync();
    }

    public async Task<Todo> SaveTodoAsync(Todo todo)
    {
        todo.Id = context.Todos.Select(todo => todo.Id).DefaultIfEmpty().Max() + 1;
        context.Todos.Add(todo);
        await context.SaveChangesAsync();
        return todo;
    }

    public async Task UpdateTodoAsync(Todo todo)
    {
        var indexToUpdate = context.Todos.FindIndex(t => t.Id == todo.Id);
        if (indexToUpdate != -1)
        {
            context.Todos[indexToUpdate] = todo;
            await context.SaveChangesAsync();
        }

    }
}
