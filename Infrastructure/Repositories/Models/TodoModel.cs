using Domain.Entities;

namespace Infrastructure.Repositories.Models;

public class TodoModel
{
    private string Id { get; set; }
    private string Owner { get; set; }
    private string Title { get; set; }
    private bool Completed { get; set; }
    private DateTime CreatedAt { get; set; }
    private DateTime? CompletedAt { get; set; }
    
    public static implicit operator TodoModel(Todo todo)
    {
        ArgumentNullException.ThrowIfNull(nameof(todo));
        
        return new TodoModel
        {
            Id = todo.Id,
            Owner = todo.Owner,
            Title = todo.Title,
            Completed = todo.Completed,
            CreatedAt = todo.CreatedAt,
            CompletedAt = todo.CompletedAt
        };
    }
    
    public static implicit operator Todo?(TodoModel? todo)
    {
        return todo is null ? null : Todo.Load(todo.Id, todo.Owner, todo.Title, todo.Completed, todo.CreatedAt, todo.CompletedAt);
    }
}