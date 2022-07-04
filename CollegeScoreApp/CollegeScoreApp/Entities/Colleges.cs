using System;
using System.ComponentModel.DataAnnotations;

namespace CollegeScoreApp.Entities
{
    public class Colleges
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(5)]
        public string Name { get; set; }
        public string Desc { get; set; }
        public int TotalRatingCount { get; set; }
        public string Picture { get; set; }
        public int  AvgRating { get; set; }
        public DateTime CreatedOn { get; set; }
        
        public Colleges()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.Now;
            Name = "UnNamed";
            Desc = "";
            TotalRatingCount = 0;
            Picture = "";
            AvgRating = 0;
        }
    }
}
