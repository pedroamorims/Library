using Library.Application.Commands.CreateUser;
using Library.Application.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllUsersQuery = new GetAllUsersQuery();
            var users = await _mediator.Send(getAllUsersQuery);

            return Ok(users);
        }

    }
}
