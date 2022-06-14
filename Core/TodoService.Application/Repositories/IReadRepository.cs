using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodoService.Domain.Entities.Common;

namespace TodoService.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool isTracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool isTracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool isTracking = true);
        Task<T> GetByIdAsync(long id, bool isTracking = true);
    }
}