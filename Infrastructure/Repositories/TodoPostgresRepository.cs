using System.Data;
using Application.Common;
using Application.OutputPorts;
using Dapper;
using Domain.Entities;
using Infrastructure.Repositories.Models;

namespace Infrastructure.Repositories;

public class TodoPostgresRepository : ITodoRepository
{
    private readonly IApplicationDbContext _context;
    private IDbConnection Connection => _context.CreateConnection();

    public TodoPostgresRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Todo?> Get(string id)
    {
        const string sql = "SELECT id, owner, title, completed, created_at as createdAt, completed_at as completedAt FROM todo WHERE id = @id";
        var todo = await Connection.QueryFirstOrDefaultAsync<TodoModel?>(sql, new { id });
        return todo;
    }

    public async Task Add(Todo entity)
    {
        const string sql = "INSERT INTO todo (id, owner, title, completed, created_at, completed_at) VALUES (@Id, @Owner, @Title, @Completed, @CreatedAt, @CompletedAt)";
        await Connection.ExecuteAsync(sql, entity);
    }

    public async Task Update(Todo entity)
    {
        const string sql = "UPDATE todo SET owner = @Owner, title = @Title, completed = @Completed, created_at = @CreatedAt, completed_at = @CompletedAt WHERE id = @Id";
        await Connection.ExecuteAsync(sql, entity);
    }

    public async Task Delete(Todo entity)
    {
        const string sql = "DELETE FROM todo WHERE id = @Id";
        await Connection.ExecuteAsync(sql, entity);
    }
}