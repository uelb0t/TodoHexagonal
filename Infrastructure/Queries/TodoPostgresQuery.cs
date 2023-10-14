using System.Data;
using Application.Common;
using Application.Queries.Todo;
using Application.Queries.Todo.Results;
using Dapper;

namespace Infrastructure.Queries;

public class TodoPostgresQuery : ITodoQuery
{
    private readonly IApplicationDbContext _context;
    private IDbConnection Connection => _context.CreateConnection();

    public TodoPostgresQuery(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TodoResult>> GetTodos()
    {
        const string sql = "SELECT id, title, completed FROM todo";
        var todos = await Connection.QueryAsync<TodoResult>(sql);
        return todos;
    }

    public async Task<TodoResult?> GetTodoById(string id)
    {
        const string sql = "SELECT id, title, completed FROM todo WHERE id = @id";
        var todo = await Connection.QueryFirstOrDefaultAsync<TodoResult>(sql, new { id });
        return todo;
    }
}