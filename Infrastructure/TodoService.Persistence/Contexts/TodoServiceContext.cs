using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoService.Domain.Entities;
using TodoService.Domain.Entities.Common;

namespace TodoService.Persistence.Contexts
{
    public class TodoServiceContext : DbContext
    {
        public TodoServiceContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries<BaseEntity>();

            foreach (var data in entries)
            {
                switch (data.State)
                {
                    case EntityState.Added:
                        _ = data.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        _ = data.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                    default:
                        _ = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}