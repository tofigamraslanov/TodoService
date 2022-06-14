using System.Collections.Generic;

namespace TodoService.Application.Features.Queries.TodoItem.GetTodoItems
{
    public class GetTodoItemQueryResponse
    {
        public List<Domain.Entities.TodoItem> TodoItems { get; set; }
    }
}