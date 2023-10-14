using Application.OutputPorts;
using Application.UseCases.Todo.CompleteTodoUseCase.Models;

namespace Application.UseCases.Todo.CompleteTodoUseCase;

public class CompleteTodoUseCase : ICompleteTodoUseCase
{
    private readonly ITodoRepository _todoRepository;

    public CompleteTodoUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<CompleteTodoUseCaseOutput> Execute(CompleteTodoUseCaseInput input)
    {
        var todo = await _todoRepository.Get(input.Id);
        if (todo is null)
            return new CompleteTodoUseCaseOutput(false, "Todo not found", null);

        todo.Complete();
        await _todoRepository.Update(todo);
        return new CompleteTodoUseCaseOutput(true, null, todo.Title);
    }
}