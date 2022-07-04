using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CollegeScoreApp.DTN;
using CollegeScoreApp.Data;
using Microsoft.EntityFrameworkCore;
using CollegeScoreApp.Entities;


namespace CollegeScoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollegeListController : ControllerBase
    {
        private readonly ILogger<CollegeList> _logger;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CollegeListController(ILogger<CollegeList> logger, IMapper mapper, AppDbContext context)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet(Name = "CollegeList")]
        public async Task<ActionResult<List<CollegeList>>> Get()
        {
            return Ok(await _context.Colleges.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CollegeList>>> Get(int id)
        {
            var college = await _context.Colleges.FindAsync(id);
            if (college == null)
                return NotFound("College NotFound");
            return Ok(college);
        }


        [HttpPost]
        public async Task<ActionResult<List<CollegeList>>> AddCollege(CollegeList collegeDTO)
        {
            var college = _mapper.Map<Colleges>(collegeDTO);
            _context.Add(college);
            return Ok(college);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<List<CollegeList>>> UpdateCollege(Guid id, [FromForm] CollegeList collegeDTO)
        {
            var college = await _context.Colleges.FirstOrDefaultAsync(x => x.Id == id);
            if (college == null)
                return NotFound();
            college = _mapper.Map(collegeDTO, college);

            await _context.SaveChangesAsync();
            return Ok(college);
        }


        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<List<CollegeList>>> DeleteCollege(Guid Id)
        {
            var college = await _context.Colleges.FirstOrDefaultAsync(x => x.Id == Id);
            if(college == null)
                return NotFound();
            _context.Remove(college);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpPut("rating/{id}")]
        public async Task<ActionResult<List<CollegeList>>> RateCollege(Guid Id, int rating)
        {
            var college = await _context.Colleges.FirstOrDefaultAsync(x => x.Id == Id);
            int totalRecords = await _context.Colleges.CountAsync();
            if (college == null)
                return NotFound();
            college.TotalRatingCount += rating;
            int avgRating = college.TotalRatingCount / totalRecords;
            college.AvgRating = avgRating;
            await _context.SaveChangesAsync();
            
            return Ok(avgRating);
        }
    }
}
