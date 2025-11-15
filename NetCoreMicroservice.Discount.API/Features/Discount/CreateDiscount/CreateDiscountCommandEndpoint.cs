using MediatR;
using NetCoreMicroservice.Shared.Extensions;
using NetCoreMicroservice.Shared.Filters;

namespace NetCoreMicroservice.Discount.API.Features.Discount.CreateDiscount
{
    public static class CreateDiscountCommandEndpoint
    {
        public static RouteGroupBuilder CreateDiscountGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/",
                async (CreateDiscountCommand command, IMediator mediator) => (await mediator.Send(command)).ToResult()).AddEndpointFilter<ValidationFilters<CreateDiscountCommand>>()
                .MapToApiVersion(1, 0)
                .WithTags("CreateDiscount");

            return group;
        }
    }
}
