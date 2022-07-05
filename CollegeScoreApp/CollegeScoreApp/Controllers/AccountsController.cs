using CollegeScoreApp.DTN;
using CollegeScoreApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CollegeScoreApp.Controllers
{
    [ApiController]
    [Route("auth/[controller]")]
    public class AccountsController : ControllerBase
    {
        public AccountsController()
        {

        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserAuth request)
        {
            if (request == null)
                return BadRequest("Username or Password is Empty");
            return Ok();
        }


        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserAuth request)
        {
            return Ok();
        }
        
    }
}
