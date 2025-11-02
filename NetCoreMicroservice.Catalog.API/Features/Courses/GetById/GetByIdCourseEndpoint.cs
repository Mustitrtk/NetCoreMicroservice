using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetCoreMicroservice.Catalog.API.Features.Categories.DTO;
using NetCoreMicroservice.Catalog.API.Features.Categories.GetById;
using NetCoreMicroservice.Catalog.API.Features.Courses.DTO;
using NetCoreMicroservice.Catalog.API.Repository;
using NetCoreMicroservice.Shared;
using NetCoreMicroservice.Shared.Extensions;
using System.Net;

namespace NetCoreMicroservice.Catalog.API.Features.Courses.GetById
{
    public record GetByIdCourseEndpointQuery(Guid Id) :IRequestByServiceResult<CourseDTO>;

    public class GetByIdCourseEndpointHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetByIdCourseEndpointQuery, ServiceResult<CourseDTO>>
    {

        public async Task<ServiceResult<CourseDTO>> Handle(GetByIdCourseEndpointQuery request, CancellationToken cancellationToken)
        {
            var course = await context.Courses.FindAsync(request.Id, cancellationToken);

            if (course is null)
            {
                return ServiceResult<CourseDTO>.Error("Course not found !", $"The category with id {request.Id} not found !", HttpStatusCode.NotFound);
            }

            var category = await context.Categories.FindAsync(course.CategoryId ,cancellationToken);

            course.Category = category;

            var coursesAsDTO = mapper.Map<CourseDTO>(course);
            return ServiceResult<CourseDTO>.SuccessAsOk(coursesAsDTO);
        }
    }

    public static class GetByIdCourseEndpoint
    {
        public static RouteGroupBuilder GetByIdCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{Id:guid}",
                async (IMediator mediator, Guid Id) => (await mediator.Send(new GetByIdCourseEndpointQuery(Id))).ToResult())
                .WithName("GetCourseById")
                .MapToApiVersion(1, 0);

            return group;
        }
    }
}
