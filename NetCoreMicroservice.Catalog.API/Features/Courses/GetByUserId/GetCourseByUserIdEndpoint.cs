using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetCoreMicroservice.Catalog.API.Features.Courses.DTO;
using NetCoreMicroservice.Catalog.API.Repository;
using NetCoreMicroservice.Shared;
using NetCoreMicroservice.Shared.Extensions;
using System.Net;

namespace NetCoreMicroservice.Catalog.API.Features.Courses.GetAllByUserId
{
    public record GetCourseByUserIdQuery(Guid userId) : IRequestByServiceResult<List<CourseDTO>>;

    public class GetCourseByUserIdHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCourseByUserIdQuery, ServiceResult<List<CourseDTO>>>
    {

        public async Task<ServiceResult<List<CourseDTO>>> Handle(GetCourseByUserIdQuery request, CancellationToken cancellationToken)
        {
            var courses = await context.Courses.Where(x=> x.UserId == request.userId).ToListAsync(cancellationToken);
            var categories = await context.Categories.ToListAsync(cancellationToken: cancellationToken);

            foreach (var course in courses)
            {
                course.Category = categories.First(x => x.Id == course.CategoryId);
            }

            var coursesAsDTO = mapper.Map<List<CourseDTO>>(courses);
            return ServiceResult<List<CourseDTO>>.SuccessAsOk(coursesAsDTO);
        }
    }

    public static class GetCourseByUserIdEndpoint
    {
        public static RouteGroupBuilder GetCourseByUserIdGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{userId:guid}",
                async (IMediator mediator, Guid userId) => (await mediator.Send(new GetCourseByUserIdQuery(userId))).ToResult())
                .MapToApiVersion(1, 0)
                .WithName("GetCourseByUserId");

            return group;
        }
    }
}
