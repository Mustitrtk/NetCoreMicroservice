using NetCoreMicroservice.Shared;

namespace NetCoreMicroservice.Catalog.API.Features.Courses.Create
{
    public record CreateCourseCommand
        (
            string Name,
            string Description,
            decimal Price,
            string? Picture,
            Guid CategoryId
        ) : IRequestByServiceResult<Guid>;
}
