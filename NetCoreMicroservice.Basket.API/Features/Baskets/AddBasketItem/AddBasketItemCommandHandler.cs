using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using NetCoreMicroservice.Basket.API.Const;
using NetCoreMicroservice.Basket.API.DTO;
using NetCoreMicroservice.Shared;
using System.Text.Json;

namespace NetCoreMicroservice.Basket.API.Features.Baskets.AddBasketItem
{
    public class AddBasketItemCommandHandler(IDistributedCache cache) : IRequestHandler<AddBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
        {
            Guid UserId = new Guid();

            var cacheKey = string.Format(BasketConst.BasketCacheKey,UserId);

            var hasBasketAsString = await cache.GetStringAsync(cacheKey,token:cancellationToken);

            BasketDTO? currentBasket;

            var currentBasketItem = new BasketItemDTO(request.CourseId, request.CourseName, request.Picture, request.CoursePrice, null);

            if (string.IsNullOrEmpty(hasBasketAsString))
            {
                currentBasket = new BasketDTO(UserId, [currentBasketItem]);
            }
            else
            {
                currentBasket = JsonSerializer.Deserialize<BasketDTO>(hasBasketAsString);

                var existItem = currentBasket.BasketItems.FirstOrDefault(x=>x.Id == request.CourseId);

                if(existItem is not null)
                {
                    currentBasket.BasketItems.Remove(existItem);
                    currentBasket.BasketItems.Add(currentBasketItem);
                }
                else
                {
                    currentBasket.BasketItems.Add(currentBasketItem);
                }
            }

            hasBasketAsString = JsonSerializer.Serialize(currentBasket);

            await cache.SetStringAsync(cacheKey, hasBasketAsString, token: cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
