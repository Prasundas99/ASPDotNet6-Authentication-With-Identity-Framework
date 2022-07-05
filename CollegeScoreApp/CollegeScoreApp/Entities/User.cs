using System.ComponentModel.DataAnnotations;

namespace CollegeScoreApp.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(5)]
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedOn { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.Now;
            Name = "UnNamed";
            
        }
    }
}
