using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoService.Application.Repositories;
using TodoService.Domain.Entities.Common;
using TodoService.Persistence.Contexts;

namespace TodoService.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly TodoServiceContext _context;
        public ReadRepository(TodoServiceContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool isTracking = true)
        {
            var query = Table.AsQueryable();

            if (!isTracking)
                query = query.AsNoTracking();

            return query;
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool isTracking = true)
        {
            var query = Table.Where(predicate);

            if (!isTracking)
                query = query.AsNoTracking();

            return query;
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool isTracking = true)
        {
            var query = Table.AsQueryable();

            if (!isTracking)
                query = Table.AsNoTracking();

            return await query.FirstOrDefaultAsync(predicate);
        }
        public async Task<T> GetByIdAsync(long id, bool isTracking = true)
        {
            var query = Table.AsQueryable();

            if (!isTracking)
                query = Table.AsNoTracking();

            return await query.FirstOrDefaultAsync(data => data.Id == id);
        }
    }
}