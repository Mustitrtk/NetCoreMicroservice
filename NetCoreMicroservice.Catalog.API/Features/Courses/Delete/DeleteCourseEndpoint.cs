using AutoMapper;
using MediatR;
using NetCoreMicroservice.Catalog.API.Features.Courses.GetById;
using NetCoreMicroservice.Catalog.API.Repository;
using NetCoreMicroservice.Shared;
using NetCoreMicroservice.Shared.Extensions;
using System.Net;

namespace NetCoreMicroservice.Catalog.API.Features.Courses.Delete
{
    public record DeleteCourseQuery(Guid Id) : IRequestByServiceResult;

    public class DeleteCourseHandler(AppDbContext context, IMapper mapper) : IRequestHandler<DeleteCourseQuery, ServiceResult>
    {

        public async Task<ServiceResult> Handle(DeleteCourseQuery request, CancellationToken cancellationToken)
        {
            var hasCourse = await context.Courses.FindAsync(request.Id, cancellationToken);
            if (hasCourse != null)
            {
                return ServiceResult.Error("Course not found !", $"The category with id {request.Id} not found !", HttpStatusCode.NotFound);
            }

            context.Courses.Remove(hasCourse);

            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }

    public static class DeleteCourseEndpoint
    {
        public static RouteGroupBuilder DeleteCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("/{Id:guid}",
                async (IMediator mediator, Guid Id) => (await mediator.Send(new DeleteCourseQuery(Id))).ToResult())
                .MapToApiVersion(1, 0)
                .WithName("DeleteCourse");

            return group;
        }
    }
}
