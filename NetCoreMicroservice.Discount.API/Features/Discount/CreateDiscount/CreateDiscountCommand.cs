using NetCoreMicroservice.Shared;

namespace NetCoreMicroservice.Discount.API.Features.Discount.CreateDiscount
{
    public record CreateDiscountCommand(string Code, float Rate, Guid UserId, DateTime Expired) : IRequestByServiceResult;
}
