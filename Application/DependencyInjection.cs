using Application.UseCases.Todo.CompleteTodoUseCase;
using Application.UseCases.Todo.CompleteTodoUseCase.Models;
using Application.UseCases.Todo.CreateTodoUseCase;
using Application.UseCases.Todo.CreateTodoUseCase.Models;
using Application.UseCases.Todo.DeleteTodoUseCase;
using Application.UseCases.Todo.DeleteTodoUseCase.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICreateTodoUseCase, CreateTodoUseCase>();
        services.AddScoped<IDeleteTodoUseCase, DeleteTodoUseCase>();
        services.AddScoped<ICompleteTodoUseCase, CompleteTodoUseCase>();

        return services;
    }
}