using System.Data;
using Application.Common;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Infrastructure;

public class DbContext : IApplicationDbContext
{
    private readonly IConfiguration _configuration;

    public DbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        return new NpgsqlConnection(connectionString);
    }
}