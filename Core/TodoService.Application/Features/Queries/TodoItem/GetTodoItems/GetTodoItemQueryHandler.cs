using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoService.Application.Repositories;

namespace TodoService.Application.Features.Queries.TodoItem.GetTodoItems
{
    public class GetTodoItemQueryHandler : IRequestHandler<GetTodoItemQueryRequest, GetTodoItemQueryResponse>
    {
        private readonly ITodoItemReadRepository _repository;

        public GetTodoItemQueryHandler(ITodoItemReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetTodoItemQueryResponse> Handle(GetTodoItemQueryRequest request, CancellationToken cancellationToken)
        {
            var todoItems = await _repository.GetAll(false).ToListAsync(cancellationToken: cancellationToken);

            return new GetTodoItemQueryResponse()
            {
                TodoItems = todoItems
            };
        }
    }
}