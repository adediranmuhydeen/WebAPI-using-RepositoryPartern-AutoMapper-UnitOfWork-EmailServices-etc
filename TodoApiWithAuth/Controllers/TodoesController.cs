using Microsoft.AspNetCore.Mvc;
using TodoApi.Core.Domain;
using TodoApi.Core.Dtos;
using TodoApi.Core.IService;
using TodoApiWithAuth.Data;

namespace TodoApiWithAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoesController : ControllerBase
    {
        private readonly ToDoAuthContext _context;
        private readonly ITodoService _todo;
        public TodoesController(ToDoAuthContext context, ITodoService todo)
        {
            _context = context;
            _todo = todo;
        }

        // GET: api/Todoes
        [HttpGet]
        public async Task<ActionResult> GetTodos()
        {
            var todos = await _todo.GetTodos();
            return Ok(todos);
        }

        // GET: api/Todoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodo([FromRoute] string id)
        {
            var todo = await _todo.GetTodoById(id);
            return Ok(todo);
        }

        // PUT: api/Todoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo([FromRoute] string id, UpdateTodoDto todoDto)
        {
            var todo = await _todo.UpdateTodo(todoDto, id);
            return Ok(todo);
        }

        // POST: api/Todoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Todo>> PostTodo([FromRoute] AddTodoDto todoDto)
        {
            var todo = await _todo.CreateTodo(todoDto);
            return Ok(todo);
        }

        // DELETE: api/Todoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] string id)
        {
            var todo = _todo.DeleteTodo(id);
            return Ok(todo);
        }

        private bool TodoExists(string id)
        {
            return (_context.Todos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
