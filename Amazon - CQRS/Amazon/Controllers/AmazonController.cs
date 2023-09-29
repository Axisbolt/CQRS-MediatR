using Amazon.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _mediator.Send(new GetUserByIdQuery { UserId = userId });

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("{userId}/orders")]
        public async Task<IActionResult> GetUserOrders(int userId)
        {
            var orders = await _mediator.Send(new GetUserOrdersQuery { UserId = userId });

            if (!orders.Orders.Any())
            {
                return NotFound("No orders found for the user.");
            }

            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand createUserCommand)
        {
            // Ensure the provided UserId is unique (you may need additional logic for this)
            if (await _mediator.Send(new CheckUserExistenceQuery { UserId = createUserCommand.UserId }))
            {
                return Conflict("A user with the same UserId already exists.");
            }

            var userId = await _mediator.Send(createUserCommand);
            return CreatedAtAction(nameof(GetUserById), new { userId }, createUserCommand);
        }
    }
}