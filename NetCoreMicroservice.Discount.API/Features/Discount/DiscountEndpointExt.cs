using Asp.Versioning.Builder;
using NetCoreMicroservice.Discount.API.Features.Discount.CreateDiscount;
using NetCoreMicroservice.Discount.API.Features.Discount.GetDiscountByCode;

namespace NetCoreMicroservice.Discount.API.Features.Discount
{
    public static class DiscountEndpointExt
    {
        public static void AddDiscountGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v:{version:apiVersion}/discouns").WithTags("Discounts")
                .WithApiVersionSet(apiVersionSet)
                .CreateDiscountGroupItemEndpoint()
                .GetDiscountByCodeGroupItemEndpoint();
        }
    }
}
