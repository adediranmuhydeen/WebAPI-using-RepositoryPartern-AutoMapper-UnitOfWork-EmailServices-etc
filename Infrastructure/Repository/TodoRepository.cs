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

        public async Task<Todo> GetByIdAsync(Func<object, bool> value)
        {
            var todo = await _dbSet.FindAsync(value);
            if (todo == null)
            {
                return null;
            }
            return todo;
        }
    }
}
