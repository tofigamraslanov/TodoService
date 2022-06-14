using TodoService.Application.Repositories;
using TodoService.Persistence.Contexts;

namespace TodoService.Persistence.Repositories
{
    public class TodoItemWriteRepository : WriteRepository<Domain.Entities.TodoItem>, ITodoItemWriteRepository
    {
        public TodoItemWriteRepository(TodoServiceContext context) : base(context)
        {

        }
    }
}