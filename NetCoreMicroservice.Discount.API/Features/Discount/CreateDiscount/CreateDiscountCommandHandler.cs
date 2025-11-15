using AutoMapper;
using MassTransit;
using MediatR;
using NetCoreMicroservice.Discount.API.Repository;
using NetCoreMicroservice.Shared;

namespace NetCoreMicroservice.Discount.API.Features.Discount.CreateDiscount
{
    public class CreateDiscountCommandHandler(AppDbContext context) : IRequestHandler<CreateDiscountCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
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
