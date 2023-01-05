using Microsoft.EntityFrameworkCore;
using TodoApi.Core.IRepository;
using TodoApiWithAuth.Data;

namespace TodoApi.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ToDoAuthContext _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(ToDoAuthContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<T> CreateAsync(T obj)
        {
            await _dbSet.AddAsync(obj);
            return obj;
        }

        public async Task<T> DeleteAsync(string Id)
        {
            var itemToBeDeleted = await _dbSet.FindAsync(Id);
            if (itemToBeDeleted == null)
            {
                return itemToBeDeleted;
            }
            _dbSet.Remove(itemToBeDeleted);
            _context.SaveChanges();
            return itemToBeDeleted;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(string Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public async Task<T> UpdateByIdAsync(string Id)
        {
            var res = await _dbSet.FindAsync(Id);
            return res;
        }
    }
}
