namespace NetCoreMicroservice.Basket.API.DTO
{
    public record BasketDTO(Guid UserId, List<BasketItemDTO> BasketItems);
}
