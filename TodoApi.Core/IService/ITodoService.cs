
using TodoApi.Core.Domain;
using TodoApi.Core.Dtos;
using TodoApiWithAuth.Utilities;

namespace TodoApi.Core.IService
{
    public interface ITodoService
    {
        Task<Response<Todo>> CreateTodo(AddTodoDto addTodo);
        Task<Response<Todo>> UpdateTodo(UpdateTodoDto updateTodo, string Id);
        Task<Response<Todo>> DeleteTodo(string Id);
        Task<IEnumerable<Todo>> GetTodos();
        Task<Response<Todo>> GetTodoById(string Id);
        Task<Response<Todo>> GetTodoByTitle(string Title);
    }
}
