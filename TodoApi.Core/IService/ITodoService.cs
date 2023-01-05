
using TodoApi.Core.Domain;
using TodoApi.Core.Dtos;
using TodoApiWithAuth.Utilities;

namespace TodoApi.Core.IService
{
    public interface ITodoService
    {
        Task<Response<Todo>> CreateTodo(AddTodoDto addTodo);
        Task<Response<Todo>> UpdateTodo(UpdateTodoDto updateTodo);
        Task<Response<Todo>> DeleteTodo();
        Task<Response<Todo>> GetTodos();
        Task<Response<Todo>> GetTodoById();
        Task<Response<Todo>> GetTodoByName();
    }
}
