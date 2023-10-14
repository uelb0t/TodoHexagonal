using Application.Queries.Todo;
using Application.UseCases.Todo.CompleteTodoUseCase.Models;
using Application.UseCases.Todo.CreateTodoUseCase.Models;
using Application.UseCases.Todo.DeleteTodoUseCase.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoQuery _todoQuery;
        private readonly ICreateTodoUseCase _createTodoUseCase;
        private readonly IDeleteTodoUseCase _deleteTodoUseCase;
        private readonly ICompleteTodoUseCase _completeTodoUseCase;

        public TodoController(ITodoQuery todoQuery, ICreateTodoUseCase createTodoUseCase, IDeleteTodoUseCase deleteTodoUseCase, ICompleteTodoUseCase completeTodoUseCase)
        {
            _todoQuery = todoQuery;
            _createTodoUseCase = createTodoUseCase;
            _deleteTodoUseCase = deleteTodoUseCase;
            _completeTodoUseCase = completeTodoUseCase;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var todos = await _todoQuery.GetTodos();
            return Ok(todos);
        }

        // GET: api/Todo/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(string id)
        {
            var todo = await _todoQuery.GetTodoById(id);

            return todo is null ? NotFound(new { message = $"There is no todo with id {id}"}) : Ok(todo);
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTodoUseCaseInput request)
        {
            var output = await _createTodoUseCase.Execute(request);

            if (!output.Success)
                return BadRequest(output);

            return CreatedAtAction(nameof(Get), new { id = output.Id }, output);
        }
        
        // PUT: api/Todo/5/complete
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> Complete(string id)
        {
            var output = await _completeTodoUseCase.Execute(new CompleteTodoUseCaseInput(id));

            if (!output.Success)
                return BadRequest(output);
            
            return Ok(output);
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var output = await _deleteTodoUseCase.Execute(new DeleteTodoUseCaseInput(id));
            
            if (!output.Success)
                return BadRequest(output);
            
            return Ok(output);
        }
    }
}
