using BookTradingHub.Application.Interfaces;
using BookTradingHub.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookTradingHub.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TodosController(ITodoService todoService) : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetTodos()
        {
            return todoService.GetTodos();
        }

        [HttpPost(Name = "SaveTodo")]
        public async Task<ActionResult> SaveTodoAsync(Todo todo)
        {
            await todoService.SaveTodoAsync(todo);
            return CreatedAtAction("SaveTodo", todo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTodoAsync(int id, Todo todo)
        {
            if (id != todo.Id)
            {
                return BadRequest();
            }
            await todoService.UpdateTodoAsync(todo);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveTodoAsync(int id)
        {
            await todoService.RemoveTodoAsync(id);
            return NoContent();
        }




    }
}
