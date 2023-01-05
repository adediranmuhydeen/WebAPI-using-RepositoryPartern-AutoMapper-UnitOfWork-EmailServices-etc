namespace TodoApi.Core.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateAsync(T obj);
        Task<T> DeleteAsync(string Id);
        Task<T> UpdateByIdAsync(string Id);
        Task<T> GetByIdAsync(string Id);
    }
}
