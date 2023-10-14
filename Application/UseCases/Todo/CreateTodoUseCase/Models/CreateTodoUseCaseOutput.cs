namespace Application.UseCases.Todo.CreateTodoUseCase.Models;

public record CreateTodoUseCaseOutput(bool Success, string? ErrorMessage, string? Id);