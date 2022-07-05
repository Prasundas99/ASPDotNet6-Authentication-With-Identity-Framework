using CollegeScoreApp.Data;
using CollegeScoreApp.DTN;
using CollegeScoreApp.DTO;
using CollegeScoreApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;


namespace CollegeScoreApp.Controllers
{
    [ApiController]
    [Route("auth/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppDbContext _context;
        public AccountsController(AppDbContext context, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }
        [HttpGet]
        public async Task<ActionResult<List<UserList>>> Get()
        {
            var user = await _userManager.GetUserAsync(User);
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserAuth request)
        {
            if (request == null)
                return BadRequest("Username or Password is Empty");
            var user = new User { Username = request.Username };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                return Ok(user);
            }
            return BadRequest();
        }


        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserAuth request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Username,
     request.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Incorrect Login");
            }
        }

       
    }
}