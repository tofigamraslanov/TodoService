using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoService.Application.Features.Commands.TodoItem.CreateTodoItem;
using TodoService.Application.Features.Commands.TodoItem.DeleteTodoItem;
using TodoService.Application.Features.Commands.TodoItem.UpdateTodoItem;
using TodoService.Application.Features.Queries.TodoItem.GetTodoItemById;
using TodoService.Application.Features.Queries.TodoItem.GetTodoItems;

namespace TodoService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator!.Send(new GetTodoItemQueryRequest()));
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            return Ok(await _mediator!.Send(new GetTodoItemByIdQueryRequest { Id = id }));
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateTodoItemCommandRequest request)
        {
            return Ok(await _mediator!.Send(request));
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            return Ok(await _mediator!.Send(new DeleteTodoItemCommandRequest() { Id = id }));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateTodoItemCommandRequest request)
        {
            return Ok(await _mediator!.Send(request));
        }
    }
}
