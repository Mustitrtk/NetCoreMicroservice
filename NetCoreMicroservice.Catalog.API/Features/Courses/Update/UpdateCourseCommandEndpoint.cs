using MediatR;
using NetCoreMicroservice.Catalog.API.Features.Courses.Create;
using NetCoreMicroservice.Shared.Extensions;
using NetCoreMicroservice.Shared.Filters;

namespace NetCoreMicroservice.Catalog.API.Features.Courses.Update
{
    public static class UpdateCourseCommandEndpoint
    {
        public static RouteGroupBuilder UpdateCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/",
                async (UpdateCourseCommand command, IMediator mediator) => (await mediator.Send(command)).ToResult()).AddEndpointFilter<ValidationFilters<UpdateCourseCommand>>()
                .MapToApiVersion(1, 0)
                .WithName("UpdateCourse");

            return group;
        }
    }
}
