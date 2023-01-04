using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoApi.Core.IRepository;
using TodoApiWithAuth.Data;

namespace TodoApi.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IMapper _mapper;
        private readonly ToDoAuthContext _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(ToDoAuthContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = context.Set<T>();
        }
        public Task<T> AddAsync(object obj)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(object obj)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateByIdAsync(string Id, object obj)
        {
            throw new NotImplementedException();
        }
    }
}
