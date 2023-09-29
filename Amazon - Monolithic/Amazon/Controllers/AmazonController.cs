using Amazon.Models;
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
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("{userId}/orders")]
        public async Task<IActionResult> GetUserOrders(int userId)
        {
            var userWithOrders = await _context.Users
                .Where(u => u.UserId == userId)
                .Include(u => u.Orders) // Include orders to retrieve associated orders
                .Select(u => new
                {
                    u.UserName,
                    Orders = u.Orders.ToList()
                })
                .FirstOrDefaultAsync();

            if (userWithOrders == null)
            {
                return NotFound();
            }

            return Ok(userWithOrders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserById), new { userId = user.UserId }, user);
        }
    }
}