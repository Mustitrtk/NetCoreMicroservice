using NetCoreMicroservice.Shared;

namespace NetCoreMicroservice.Discount.API.Features.Discount.GetDiscountByCode
{
    public record GetDiscountByCodeQuery(string Code): IRequestByServiceResult<GetDiscountByCodeQueryResponse>;
}
