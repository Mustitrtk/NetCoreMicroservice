using AutoMapper;
using NetCoreMicroservice.Catalog.API.Features.Courses.Create;
using NetCoreMicroservice.Catalog.API.Features.Courses.DTO;

namespace NetCoreMicroservice.Catalog.API.Features.Courses
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Feature, FeatureDTO>().ReverseMap();
        }
    }
}
