using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodoService.Application.Repositories;

namespace TodoService.Application.Features.Queries.TodoItem.GetTodoItemById
{
    public class GetTodoItemByIdQueryHandler : IRequestHandler<GetTodoItemByIdQueryRequest, GetTodoItemByIdQueryResponse>
    {
        private readonly ITodoItemReadRepository _repository;

        public GetTodoItemByIdQueryHandler(ITodoItemReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetTodoItemByIdQueryResponse> Handle(GetTodoItemByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var todoItem = await _repository.GetByIdAsync(request.Id, false);
            return new GetTodoItemByIdQueryResponse()
            {
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
        }
    }
}