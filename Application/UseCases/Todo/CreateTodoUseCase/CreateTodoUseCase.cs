using Application.OutputPorts;
using Application.UseCases.Todo.CreateTodoUseCase.Models;

namespace Application.UseCases.Todo.CreateTodoUseCase;

public class CreateTodoUseCase : ICreateTodoUseCase
{
    private readonly ITodoRepository _todoRepository;
    private static readonly List<string> AvailableOwners = new() { "user1", "user2", "user3" };

    public CreateTodoUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }
    
    public async Task<CreateTodoUseCaseOutput> Execute(CreateTodoUseCaseInput input)
    {
        if (string.IsNullOrWhiteSpace(input.Title))
            return new CreateTodoUseCaseOutput(false, "Title can not be null or empty", null);
        if (string.IsNullOrWhiteSpace(input.Owner))
            return new CreateTodoUseCaseOutput(false, "Owner can not be null or empty", null);
        if (!AvailableOwners.Contains(input.Owner))
            return new CreateTodoUseCaseOutput(false, "Owner is not valid", null);
        
        var todo = new Domain.Entities.Todo(input.Owner, input.Title);
        await _todoRepository.Add(todo);
        return new CreateTodoUseCaseOutput(true, null, todo.Id);
    }
}