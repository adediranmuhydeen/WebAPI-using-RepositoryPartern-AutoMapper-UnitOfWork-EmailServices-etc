using TodoApi.Core.Domain;
using TodoApi.Core.IRepository;
using TodoApiWithAuth.Data;

namespace TodoApi.Infrastructure.Repository
{
    public class TodoRepository : GenericRepository<Todo>, ITodoRepository
    {
        public TodoRepository(ToDoAuthContext todoContext) : base(todoContext)
        {

        }
    }
}
