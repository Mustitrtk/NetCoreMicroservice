using NetCoreMicroservice.Shared;

namespace NetCoreMicroservice.Basket.API.Features.Baskets.AddBasketItem
{
    public record AddBasketItemCommand(Guid CourseId, string CourseName, decimal CoursePrice, string? Picture) : IRequestByServiceResult;
}
