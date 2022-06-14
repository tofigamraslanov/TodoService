using MediatR;

namespace TodoService.Application.Features.Commands.TodoItem.CreateTodoItem
{
    public class CreateTodoItemCommandRequest : IRequest<CreateTodoItemCommandResponse>
    {
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}