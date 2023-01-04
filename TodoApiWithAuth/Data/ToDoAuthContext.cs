using Microsoft.EntityFrameworkCore;
using TodoApi.Core.Domain;

namespace TodoApiWithAuth.Data
{
    public class ToDoAuthContext : DbContext
    {
        public ToDoAuthContext(DbContextOptions<ToDoAuthContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
