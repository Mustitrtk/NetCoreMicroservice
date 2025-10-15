using AutoMapper;
using NetCoreMicroservice.Catalog.API.Features.Courses.Create;

namespace NetCoreMicroservice.Catalog.API.Features.Courses
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<CreateCourseCommand, Course>();
        }
    }
}
