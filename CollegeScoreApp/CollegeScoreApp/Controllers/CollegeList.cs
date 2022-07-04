using Microsoft.AspNetCore.Mvc;
using CollegeScoreApp.DTN;
using CollegeScoreApp.Data;

namespace CollegeScoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollegeListController : ControllerBase
    {
        private readonly ILogger<CollegeList> _logger;
        private readonly AppDbContext _context;

        public CollegeListController(ILogger<CollegeList> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context; 
        }

        [HttpGet(Name = "CollegeList")]
        public async Task<ActionResult<List<CollegeList>>> Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CollegeList>>> Get(int id)
        {
            //var college = await 
            return Ok();
        }


        [HttpPost]
        public async Task<ActionResult<List<CollegeList>>> AddCollege(CollegeList college)
        {
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<CollegeList>>> UpdateCollege(CollegeList college)
        {
            return BadRequest();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CollegeList>>> DeleteCollege(CollegeList college)
        {
            return BadRequest();
        }

    }
}
