using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodoService.Application.Repositories;

namespace TodoService.Application.Features.Commands.TodoItem.DeleteTodoItem
{
    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommandRequest, DeleteTodoItemCommandResponse>
    {
        private readonly ITodoItemWriteRepository _repository;

        public DeleteTodoItemCommandHandler(ITodoItemWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteTodoItemCommandResponse> Handle(DeleteTodoItemCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAsync(request.Id);
            await _repository.SaveAsync();

            return new DeleteTodoItemCommandResponse();
        }
    }
}