using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetCoreMicroservice.Catalog.API.Features.Categories.Create;
using NetCoreMicroservice.Catalog.API.Features.Categories.DTO;
using NetCoreMicroservice.Catalog.API.Repository;
using NetCoreMicroservice.Shared;
using NetCoreMicroservice.Shared.Extensions;
using NetCoreMicroservice.Shared.Filters;

namespace NetCoreMicroservice.Catalog.API.Features.Categories.GetAll
{

    public class GetAllCategoryQuery:IRequestByServiceResult<List<CategoryDTO>>;


    public class GetAllCategoryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCategoryQuery,ServiceResult<List<CategoryDTO>>>
    {
        public async Task<ServiceResult<List<CategoryDTO>>> Handle (GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await context.Categories.ToListAsync(cancellationToken: cancellationToken);
            var categoriesAsDTO = mapper.Map<List<CategoryDTO>>(categories);
            return ServiceResult<List<CategoryDTO>>.SuccessAsOk(categoriesAsDTO);
        }
    }

    public static class GetAllCategoryEndpoint
    {
        public static RouteGroupBuilder GetAllCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/",
                async (IMediator mediator) => (await mediator.Send(new GetAllCategoryQuery())).ToResult());

            return group;
        }
    }
}
