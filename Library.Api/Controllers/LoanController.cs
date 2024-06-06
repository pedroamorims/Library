using Azure;
using Library.Application.Commands.CreateLoan;
using Library.Application.Commands.ReturnLoan;
using Library.Application.Queries.GetAllLoans;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLoanCommand command)
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

        [HttpPut("ReturnLoan")]
        public async Task<IActionResult> ReturnLoan(ReturnLoanCommand command)
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
            var getAllLoansQuery = new GetAllLoansQuery();
            var loans = await _mediator.Send(getAllLoansQuery);
            return Ok(loans);
        }


    }
}
