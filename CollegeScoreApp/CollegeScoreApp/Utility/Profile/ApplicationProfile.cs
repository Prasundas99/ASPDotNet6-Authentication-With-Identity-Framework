using CollegeScoreApp.DTN;
using CollegeScoreApp.Entities;

namespace CollegeScoreApp.Utility.Profile
{
    public class ApplicationProfile: AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Colleges, CollegeList>().ReverseMap();
        }
    }
}
