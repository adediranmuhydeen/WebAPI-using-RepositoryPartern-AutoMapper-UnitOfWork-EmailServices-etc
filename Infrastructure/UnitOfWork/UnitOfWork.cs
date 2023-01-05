using Microsoft.Build.Framework;
using TodoApi.Core.IRepository;
using TodoApi.Infrastructure.Repository;
using TodoApiWithAuth.Data;

namespace TodoApi.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoAuthContext _todoContext;
        private ITodoRepository _todoRepository;
        private readonly ILogger _logger;
        public UnitOfWork(ToDoAuthContext todoContext, ILogger logger)
        {
            _todoContext = todoContext;
            _logger = logger;
        }
        public ITodoRepository todoRepository => _todoRepository ??= new TodoRepository(_todoContext);

        public void Dispose()
        {
            try
            {
                _todoContext.Dispose();
            }
            catch (ArgumentNullException aex)
            {
                aex.Equals(null);
            }
            catch (Exception ex)
            {
                ex.Equals(null);
            }
            finally { GC.SuppressFinalize(this); }

        }
        public async Task SaveChanges()
        {
            await _todoContext.SaveChangesAsync();
        }
    }
}
