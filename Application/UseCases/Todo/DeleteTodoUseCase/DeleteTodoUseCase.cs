using Application.OutputPorts;
using Application.UseCases.Todo.DeleteTodoUseCase.Models;

namespace Application.UseCases.Todo.DeleteTodoUseCase;

public class DeleteTodoUseCase : IDeleteTodoUseCase
{
    private readonly ITodoRepository _todoRepository;

    public DeleteTodoUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<DeleteTodoUseCaseOutput> Execute(DeleteTodoUseCaseInput input)
    {
        var todo = await _todoRepository.Get(input.Id);
        if (todo is null)
            return new DeleteTodoUseCaseOutput(false, "Todo not found");

        await _todoRepository.Delete(todo);
        return new DeleteTodoUseCaseOutput(true, null);
    }
}