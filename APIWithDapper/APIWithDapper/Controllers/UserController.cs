using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIWithDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        // if you want to call IHandler file 
        // private readonly IUsers _users;
        public UserController(IConfiguration config 
        //IUsers users
        )
        {
            _config = config;
            //_users = users;
        }

        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetAllUsers()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            using var command = connection.QueryAsync<Users>("select * from users");
            return Ok(command.Result);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Users>>> GetAllUserById(int userId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            using var command = connection.QueryAsync<Users>($"select * from users where UserId = {userId}");
            return Ok(command.Result);
        }

        [HttpPost]

        public async Task<ActionResult<List<Users>>> CreateUser(Users user)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync($"INSERT INTO Users (UserId, UserName, Email) VALUES ({user.UserId}, '{user.UserName}', '{user.Email}')");
            return Ok("Ho gaya, Tea break");
       

        }

    }
}
