using MediatR;

namespace TodoService.Application.Features.Commands.TodoItem.UpdateTodoItem
{
    public class UpdateTodoItemCommandRequest : IRequest<UpdateTodoItemCommandResponse>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}