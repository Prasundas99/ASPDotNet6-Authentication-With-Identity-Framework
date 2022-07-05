using CollegeScoreApp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CollegeScoreApp.Data
{
    public class AppDbContext :  IdentityDbContext
    {
         public  AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
          {
          }

        public DbSet<Colleges> Colleges { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
