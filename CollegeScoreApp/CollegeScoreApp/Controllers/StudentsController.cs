using CollegeScoreApp.Data;
using CollegeScoreApp.DTO;
using CollegeScoreApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeScoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Students>>> Get(Guid CollegeId)
        {
            System.Linq.Expressions.Expression<Func<Students, bool>> predicate = x => x.CollegeID == CollegeId;
            var students =  _context.Students.Where(predicate).ToListAsync();

            return Ok(students);

        }

        [HttpPost]
        public async Task<ActionResult<List<Students>>> Create(CreateStudent createStudent)
        {
            var college = await _context.Colleges.FindAsync(createStudent.CollegeId);
           // if (college == null)
             //   return NotFound();

            var newStudent = new Students
            {
                Name = createStudent.Name,
                Address = createStudent.Address,
                Desc = createStudent.Desc
            };

            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();
            return await Get(newStudent.Id);
        }
    }
}
