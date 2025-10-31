
using NetCoreMicroservice.Catalog.API.Features.Courses.Create;
using NetCoreMicroservice.Catalog.API.Features.Courses.GetAll;
using NetCoreMicroservice.Catalog.API.Features.Courses.GetById;
using NetCoreMicroservice.Catalog.API.Features.Courses.Update;

namespace NetCoreMicroservice.Catalog.API.Features.Courses
{
    public static class CourseEndpointExt
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("api/courses").WithTags("Courses")
                .CreateCourseGroupItemEndpoint()
                .GetAllCoursesGroupItemEndpoint()
                .GetByIdCourseGroupItemEndpoint()
                .UpdateCourseGroupItemEndpoint();
        }
    }
}
