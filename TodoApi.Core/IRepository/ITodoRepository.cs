using TodoApi.Core.Domain;

namespace TodoApi.Core.IRepository
{
    public interface ITodoRepository : IGenericRepository<Todo>
    {
        Task<Todo> GetByIdAsync(Func<object, bool> value);
    }
}
