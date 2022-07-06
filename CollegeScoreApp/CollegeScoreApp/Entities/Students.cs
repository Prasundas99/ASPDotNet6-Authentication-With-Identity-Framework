using System.ComponentModel.DataAnnotations;

namespace CollegeScoreApp.Entities
{
    public class Students
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(5)]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Desc { get; set; }
        public string Picture { get; set; }
        public Colleges Colleges { get; set; }
        public Guid CollegeID { get; set; }

        public DateTime CreatedOn { get; set; }

        public Students()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.Now;
            Name = "UnNamed";
            Address = string.Empty;
            Desc = "";
            Colleges = new Colleges();
            Picture = "https://images.unsplash.com/photo-1606761568499-6d2451b23c66?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1074&q=80";
        }
    }
}
