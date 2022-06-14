using MediatR;

namespace TodoService.Application.Features.Queries.TodoItem.GetTodoItemById
{
    public class GetTodoItemByIdQueryRequest : IRequest<GetTodoItemByIdQueryResponse>
    {
        public long Id { get; set; }
    }
}