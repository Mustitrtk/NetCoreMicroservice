using NetCoreMicroservice.Catalog.API.Features.Categories.Create;
using NetCoreMicroservice.Catalog.API.Features.Categories.GetAll;

namespace NetCoreMicroservice.Catalog.API.Features.Categories
{
    public static class CategoryEndpointExt
    {
        public static void AddCategoryGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("api/categories")
                .CreateCategoryGroupItemEndpoint()
                .GetAllCategoryGroupItemEndpoint();
        }
    }
}
