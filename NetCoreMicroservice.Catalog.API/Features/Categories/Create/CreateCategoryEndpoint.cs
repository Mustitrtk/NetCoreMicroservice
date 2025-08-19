using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using NetCoreMicroservice.Shared.Extensions;

namespace NetCoreMicroservice.Catalog.API.Features.Categories.Create
{
    public static class CreateCategoryEndpoint
    {
        public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/", 
                async (CreateCategoryCommand command, IMediator mediator) => (await mediator.Send(command)).ToResult());

            return group;
        }
    }
}
