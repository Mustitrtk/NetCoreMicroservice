using NetCoreMicroservice.Catalog.API.Features.Categories.DTO;

namespace NetCoreMicroservice.Catalog.API.Features.Courses.DTO
{
    public record CourseDTO(
        Guid Id, 
        string Name, 
        string Description, 
        decimal Price, 
        string Picture,
        CategoryDTO Category,
        FeatureDTO Feature);
}
