namespace NetCoreMicroservice.Basket.API.DTO
{
    public record BasketItemDTO(
        Guid Id,
        string Name,
        string? Picture,
        decimal Price,
        decimal? PriceByApplyDiscountRate
    );
}
