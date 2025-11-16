using MediatR;
using Microsoft.EntityFrameworkCore;
using NetCoreMicroservice.Discount.API.Repository;
using NetCoreMicroservice.Shared;
using System.Net;

namespace NetCoreMicroservice.Discount.API.Features.Discount.GetDiscountByCode
{
    public class GetDiscountByCodeQueryHandler(AppDbContext context) : IRequestHandler<GetDiscountByCodeQuery, ServiceResult<GetDiscountByCodeQueryResponse>>
    {
        public async Task<ServiceResult<GetDiscountByCodeQueryResponse>> Handle(GetDiscountByCodeQuery request, CancellationToken cancellationToken)
        {
            var hasDiscount = await context.Discounts.SingleOrDefaultAsync(x => x.Code == request.Code, cancellationToken: cancellationToken);

            if (hasDiscount == null)
            {
                return ServiceResult<GetDiscountByCodeQueryResponse>.Error(title:"Discount not found!", HttpStatusCode.NotFound);
            }

            if (hasDiscount.Expired < DateTime.Now)
            {
                return ServiceResult<GetDiscountByCodeQueryResponse>.Error(title: "Discount expired!", HttpStatusCode.BadRequest);
            }

            return ServiceResult<GetDiscountByCodeQueryResponse>.SuccessAsOk(new GetDiscountByCodeQueryResponse
            (
                hasDiscount.Code,
                hasDiscount.Rate
            ));
        }
    }
}
