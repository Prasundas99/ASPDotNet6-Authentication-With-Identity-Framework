using Microsoft.EntityFrameworkCore;

namespace CollegeScoreApp.Data
{
    public class AppDbContext : DbContext
    {
         public  AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
          {
          }
    }
}
