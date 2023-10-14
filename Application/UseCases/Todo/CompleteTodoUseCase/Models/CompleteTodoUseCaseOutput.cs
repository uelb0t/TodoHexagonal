namespace Application.UseCases.Todo.CompleteTodoUseCase.Models;

public record CompleteTodoUseCaseOutput(bool Success, string? ErrorMessage, string? Title);