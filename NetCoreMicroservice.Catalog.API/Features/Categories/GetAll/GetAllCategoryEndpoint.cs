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

    public class GetAllCategoryQuery:IRequest<ServiceResult<List<CategoryDTO>>>;


    public class GetAllCategoryHandler(AppDbContext context) : IRequestHandler<GetAllCategoryQuery,ServiceResult<List<CategoryDTO>>>
    {
        public async Task<ServiceResult<List<CategoryDTO>>> Handle (GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await context.Categories.ToListAsync();
            var categoriesAsDTO = categories.Select(x=> new CategoryDTO(x.Id,x.Name)).ToList();
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
