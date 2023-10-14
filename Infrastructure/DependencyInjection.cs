using Application.Common;
using Application.OutputPorts;
using Application.Queries.Todo;
using Infrastructure.Queries;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IApplicationDbContext, DbContext>(provider => new DbContext(configuration));
        services.AddScoped<ITodoQuery, TodoPostgresQuery>();
        services.AddScoped<ITodoRepository, TodoPostgresRepository>();

        return services;
    }
}