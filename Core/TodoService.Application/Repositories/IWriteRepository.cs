using System.Collections.Generic;
using System.Threading.Tasks;
using TodoService.Domain.Entities.Common;

namespace TodoService.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T item);
        Task<bool> AddRangeAsync(List<T> items);
        bool Remove(T item);
        bool RemoveRange(List<T> items);
        Task<bool> RemoveAsync(long id);
        bool Update(T item);

        Task<int> SaveAsync();
    }
}