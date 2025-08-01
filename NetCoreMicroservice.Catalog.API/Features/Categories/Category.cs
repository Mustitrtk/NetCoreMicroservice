using NetCoreMicroservice.Catalog.API.Features.Courses;
using NetCoreMicroservice.Catalog.API.Repository;

namespace NetCoreMicroservice.Catalog.API.Features.Categories
{
    public class Category : BaseEntity
    {
        public String Name { get; set; } = default!;
        public List<Course>? Courses { get; set; }
    }
}
