using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetCoreMicroservice.Discount.API.Repository;
using NetCoreMicroservice.Shared;
using System.Net;

namespace NetCoreMicroservice.Discount.API.Features.Discount.CreateDiscount
{
    public class CreateDiscountCommandHandler(AppDbContext context) : IRequestHandler<CreateDiscountCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var hasCodeForUser = await context.Discounts.AnyAsync(
            x => x.UserId.ToString() == request.UserId.ToString() && x.Code == request.Code, cancellationToken);


            if (hasCodeForUser)
                return ServiceResult.Error(title:"Discount code already exists for this user", HttpStatusCode.BadRequest);

            var discount = new DiscountEntity()
            {
                Id = NewId.NextSequentialGuid(),
                Code = request.Code,
                Rate = request.Rate,
                UserId = request.UserId,
                Expired = request.Expired,
            };

            await context.Discounts.AddAsync(discount,cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();

        }
    }
}
