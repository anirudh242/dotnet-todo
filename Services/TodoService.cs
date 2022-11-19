using TodoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Services;

public class TodoService 
{
    private readonly DataContext context;

    public TodoService(DataContext context) {
        this.context = context;
    }
    public async Task<ActionResult<List<Todo>>> GetAll()
    {
        return await context.Todos.ToListAsync();
    }

    public Todo? GetById(int id) => context.Todos.Find(id);

    public void AddTodo(Todo todo)
    {
        context.Todos.Add(todo);
        context.SaveChanges();
    }

    public void Update(Todo updatedTodo)
    {
        var todo = context.Todos.Find(updatedTodo.Id);
        if (todo is null)
            return;
        
        todo.Name = updatedTodo.Name;
        todo.Status = updatedTodo.Status;

        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var todo = context.Todos.Find(id);
        if (todo is null)
            return;

        context.Todos.Remove(todo);
        context.SaveChanges();
    }
}