namespace CollegeScoreApp.DTO
{
    public class CreateStudent
    {
        public Guid CollegeId   { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty ;
        public string Desc { get; set; } = string.Empty;
    }
}
