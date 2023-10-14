using Application.Queries.Todo.Results;

namespace Application.Queries.Todo;

public interface ITodoQuery
{
    Task<IEnumerable<TodoResult>> GetTodos();
    Task<TodoResult?> GetTodoById(string id);
}