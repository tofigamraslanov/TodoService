using TodoService.Application.Repositories;
using TodoService.Persistence.Contexts;

namespace TodoService.Persistence.Repositories
{
    public class TodoItemReadRepository : ReadRepository<Domain.Entities.TodoItem>, ITodoItemReadRepository
    {
        public TodoItemReadRepository(TodoServiceContext context) : base(context)
        {

        }
    }
}