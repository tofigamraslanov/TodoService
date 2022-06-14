using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodoService.Application.Repositories;

namespace TodoService.Application.Features.Commands.TodoItem.CreateTodoItem
{
    public class CreateTodoItemCommandHandler :
        IRequestHandler<CreateTodoItemCommandRequest, CreateTodoItemCommandResponse>
    {
        private readonly ITodoItemWriteRepository _repository;

        public CreateTodoItemCommandHandler(ITodoItemWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateTodoItemCommandResponse> Handle(CreateTodoItemCommandRequest request,
            CancellationToken cancellationToken)
        {
            await _repository.AddAsync(new Domain.Entities.TodoItem()
            {
                Name = request.Name,
                IsComplete = request.IsComplete,
            });
            await _repository.SaveAsync();

            return new CreateTodoItemCommandResponse();
        }
    }
}