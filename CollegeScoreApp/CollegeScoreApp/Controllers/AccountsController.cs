using CollegeScoreApp.Data;
using CollegeScoreApp.DTN;
using CollegeScoreApp.DTO;
using CollegeScoreApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace CollegeScoreApp.Controllers
{
    [ApiController]
    [Route("auth/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AccountsController(AppDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<List<UserList>>> Get()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserAuth request)
        {
            if (request == null)
                return BadRequest("Username or Password is Empty");
            var userExist = await _context.Users.FirstOrDefaultAsync(x => x.Username == request.Username);
            if (userExist != null)
                return BadRequest("UserExists");

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User { Username = request.Username ; PasswordHash = passwordHash; passwordSalt };


        _context.Users.Add(user);
            return Ok();
        }


        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserAuth request)
        {
            if (request == null)
                return BadRequest("Username or Password is Empty");

            return Ok();
        }


    private string GenerateJwtToken(User user)
    {
        List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("My to Secrect key hello world"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

}
}
