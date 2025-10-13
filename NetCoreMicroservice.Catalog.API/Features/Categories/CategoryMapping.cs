using AutoMapper;
using NetCoreMicroservice.Catalog.API.Features.Categories.DTO;

namespace NetCoreMicroservice.Catalog.API.Features.Categories
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category,CategoryDTO>().ReverseMap();
        }
    }
}
