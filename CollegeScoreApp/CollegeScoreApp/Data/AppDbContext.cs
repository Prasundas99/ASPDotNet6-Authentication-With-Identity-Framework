using CollegeScoreApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollegeScoreApp.Data
{
    public class AppDbContext : DbContext
    {
         public  AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
          {
          }

        public DbSet<Colleges> Colleges { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
