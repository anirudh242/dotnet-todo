using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    public TodoService todoService;

    public TodoController(DataContext context)
    {
        todoService = new TodoService(context);
    }


    [HttpGet]
    public Task<ActionResult<List<Todo>>> GetAll() => todoService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Todo> GetById(int id)
    {
        var todo = todoService.GetById(id);
        
        if (todo is null)
            return NotFound();
        
        return todo;
    }

    [HttpPost]
    public IActionResult CreateTodo(Todo todo)
    {
        todoService.AddTodo(todo);
        return CreatedAtAction(nameof(CreateTodo), new { id = todo.Id }, todo);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTodo(int id, Todo todo)
    {
        if (id != todo.Id)
            return BadRequest("IDs do not match");

        todoService.Update(todo);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTodo(int id)
    {
        if (todoService.GetById(id) is null)
            return NotFound();

        todoService.Delete(id);
        return NoContent();
    }
}