namespace TodoApi.Core.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AddAsync(object obj);
        Task<bool> DeleteAsync(string Id);
        Task<bool> UpdateAsync(object obj);
        Task<bool> UpdateByIdAsync(string Id, object obj);
        Task<T> GetByIdAsync(string Id);
    }
}
