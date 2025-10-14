using AutoMapper;
using MediatR;
using NetCoreMicroservice.Catalog.API.Features.Categories.DTO;
using NetCoreMicroservice.Catalog.API.Features.Categories.GetAll;
using NetCoreMicroservice.Catalog.API.Repository;
using NetCoreMicroservice.Shared;
using NetCoreMicroservice.Shared.Extensions;
using System.Net;

namespace NetCoreMicroservice.Catalog.API.Features.Categories.GetById
{
    public record GetCategoryByIdQuery(Guid Id) : IRequestByServiceResult<CategoryDTO>;

    public class GetCategoryByIdHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, ServiceResult<CategoryDTO>>
    {
        public async Task<ServiceResult<CategoryDTO>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await context.Categories.FindAsync(request.Id, cancellationToken);

            if (category is null)
            {
                return ServiceResult<CategoryDTO>.Error("Category not found !", $"The category with id {request.Id} not found !", HttpStatusCode.NotFound);
            }

            var categoryDTO = mapper.Map<CategoryDTO>(category);

            return ServiceResult<CategoryDTO>.SuccessAsOk(categoryDTO);
        }
    }

    public static class GetCategoryByIdEndpoint
    {
        public static RouteGroupBuilder GetByIdCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}",
                async (IMediator mediator, Guid id) => (await mediator.Send(new GetCategoryByIdQuery(id))).ToResult());

            return group;
        }
    }
}
