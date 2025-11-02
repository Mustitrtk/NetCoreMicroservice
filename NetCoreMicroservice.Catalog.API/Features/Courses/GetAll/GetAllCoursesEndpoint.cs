using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetCoreMicroservice.Catalog.API.Features.Courses.Create;
using NetCoreMicroservice.Catalog.API.Features.Courses.DTO;
using NetCoreMicroservice.Catalog.API.Repository;
using NetCoreMicroservice.Shared;
using NetCoreMicroservice.Shared.Extensions;
using NetCoreMicroservice.Shared.Filters;

namespace NetCoreMicroservice.Catalog.API.Features.Courses.GetAll
{

    public record GetAllCoursesQuery(): IRequestByServiceResult<List<CourseDTO>>;

    public class GetAllCoursesHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCoursesQuery, ServiceResult<List<CourseDTO>>>
    {
        public async Task<ServiceResult<List<CourseDTO>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await context.Courses.ToListAsync(cancellationToken:cancellationToken);
            var categories = await context.Categories.ToListAsync(cancellationToken:cancellationToken);

            foreach(var course in courses)
            {
                course.Category = categories.First(x=>x.Id == course.CategoryId);
            }

            var coursesAsDTO = mapper.Map<List<CourseDTO>>(courses);
            return ServiceResult<List<CourseDTO>>.SuccessAsOk(coursesAsDTO);
        }
    }

    public static class GetAllCoursesEndpoint
    {
        public static RouteGroupBuilder GetAllCoursesGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/",
                async (IMediator mediator) => (await mediator.Send(new GetAllCoursesQuery())).ToResult())
                .MapToApiVersion(1, 0)
                .WithName("GetAllCourses");

            return group;
        }
    }
}
