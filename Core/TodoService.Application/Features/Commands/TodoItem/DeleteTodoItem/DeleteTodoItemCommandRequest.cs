using MediatR;

namespace TodoService.Application.Features.Commands.TodoItem.DeleteTodoItem
{
    public class DeleteTodoItemCommandRequest : IRequest<DeleteTodoItemCommandResponse>
    {
        public long Id { get; set; }
    }
}