using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoService.Application.Repositories;
using TodoService.Domain.Entities.Common;
using TodoService.Persistence.Contexts;

namespace TodoService.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        readonly private TodoServiceContext _context;

        public WriteRepository(TodoServiceContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T item)
        {
            var entityEntry = await Table.AddAsync(item);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> items)
        {
            await Table.AddRangeAsync(items);
            return true;
        }

        public bool Remove(T item)
        {
            var entityEntry = Table.Remove(item);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> items)
        {
            Table.RemoveRange(items);
            return true;
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var todoItem = await Table.FindAsync(id);
            return Remove(todoItem);
        }

        public bool Update(T item)
        {
            EntityEntry entityEntry = Table.Update(item);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

    }
}