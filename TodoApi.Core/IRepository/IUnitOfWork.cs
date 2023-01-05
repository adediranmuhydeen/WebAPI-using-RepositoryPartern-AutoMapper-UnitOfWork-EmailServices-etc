namespace TodoApi.Core.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ITodoRepository todoRepository { get; }
        Task SaveChanges();
        void Dispose();
    }
}
