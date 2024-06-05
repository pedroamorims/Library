using Library.Application.Commands.CreateWaitList;
using Library.Application.Queries.GetAllWaitLists;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaitListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WaitListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateWaitListCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);

                if (!response.IsSuccess)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllWaitListsQuery = new GetAllWaitListQuery();
            var loans = await _mediator.Send(getAllWaitListsQuery);
            return Ok(loans);
        }


    }
}
