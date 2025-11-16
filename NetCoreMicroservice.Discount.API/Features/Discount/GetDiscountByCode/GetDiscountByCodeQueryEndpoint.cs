using MediatR;
using NetCoreMicroservice.Shared.Extensions;
using NetCoreMicroservice.Shared.Filters;

namespace NetCoreMicroservice.Discount.API.Features.Discount.GetDiscountByCode
{
    public static class GetDiscountByCodeQueryEndpoint
    {
        public static RouteGroupBuilder GetDiscountByCodeGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{code:length(6)}",
                async (string code, IMediator mediator) => (await mediator.Send(new GetDiscountByCodeQuery(code))).ToResult())
                .MapToApiVersion(1, 0)
                .WithName("GetDiscountByCode");

            return group;
        }
    }
}
