
using Asp.Versioning.Builder;
using NetCoreMicroservice.Catalog.API.Features.Courses.Create;
using NetCoreMicroservice.Catalog.API.Features.Courses.Delete;
using NetCoreMicroservice.Catalog.API.Features.Courses.GetAll;
using NetCoreMicroservice.Catalog.API.Features.Courses.GetAllByUserId;
using NetCoreMicroservice.Catalog.API.Features.Courses.GetById;
using NetCoreMicroservice.Catalog.API.Features.Courses.Update;

namespace NetCoreMicroservice.Catalog.API.Features.Courses
{
    public static class CourseEndpointExt
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v:{version:apiVersion}/courses").WithTags("Courses")
                .WithApiVersionSet(apiVersionSet)
                .CreateCourseGroupItemEndpoint()
                .GetAllCoursesGroupItemEndpoint()
                .GetByIdCourseGroupItemEndpoint()
                .UpdateCourseGroupItemEndpoint()
                .DeleteCourseGroupItemEndpoint()
                .GetCourseByUserIdGroupItemEndpoint();
        }
    }
}
