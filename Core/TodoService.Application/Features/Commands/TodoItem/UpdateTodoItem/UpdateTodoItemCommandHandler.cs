using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodoService.Application.Repositories;

namespace TodoService.Application.Features.Commands.TodoItem.UpdateTodoItem
{
    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommandRequest, UpdateTodoItemCommandResponse>
    {
        private readonly ITodoItemWriteRepository _writeRepository;
        private readonly ITodoItemReadRepository _readRepository;

        public UpdateTodoItemCommandHandler(ITodoItemWriteRepository writeRepository, ITodoItemReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<UpdateTodoItemCommandResponse> Handle(UpdateTodoItemCommandRequest request, CancellationToken cancellationToken)
        {
            var todoItem = await _readRepository.GetByIdAsync(request.Id);

            todoItem.Name = request.Name;
            todoItem.IsComplete = request.IsComplete;
            await _writeRepository.SaveAsync();

            return new UpdateTodoItemCommandResponse();
        }
    }
}