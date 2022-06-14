using Microsoft.EntityFrameworkCore;
using TodoService.Domain.Entities.Common;

namespace TodoService.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}