using MediatR;
using NetCoreMicroservice.Catalog.API.Features.Courses.DTO;
using NetCoreMicroservice.Shared;
using Refit;

namespace NetCoreMicroservice.Catalog.API.Features.Courses.Update
{
    public record UpdateCourseCommand(
        Guid Id, 
        string Name, 
        string Description, 
        decimal Price, 
        string? Picture, 
        Guid CategoryId) : IRequestByServiceResult;
}
