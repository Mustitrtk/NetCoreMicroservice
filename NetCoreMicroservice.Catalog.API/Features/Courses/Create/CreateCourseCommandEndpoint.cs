using MediatR;
using NetCoreMicroservice.Catalog.API.Features.Categories.Create;
using NetCoreMicroservice.Shared.Extensions;
using NetCoreMicroservice.Shared.Filters;

namespace NetCoreMicroservice.Catalog.API.Features.Courses.Create
{
    public static class CreateCourseCommandEndpoint
    {
        public static RouteGroupBuilder CreateCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/",
                async (CreateCourseCommand command, IMediator mediator) => (await mediator.Send(command)).ToResult()).AddEndpointFilter<ValidationFilters<CreateCourseCommand>>();

            return group;
        }
    }
}
