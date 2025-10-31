using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetCoreMicroservice.Catalog.API.Repository;
using NetCoreMicroservice.Shared;
using System.Net;

namespace NetCoreMicroservice.Catalog.API.Features.Courses.Update
{
    public class UpdateCourseHandler(AppDbContext context, IMapper mapper) : IRequestHandler<UpdateCourseCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var hasCourse = await context.Courses.FindAsync(request.Id,cancellationToken);

            if (hasCourse == null)
            {
                return ServiceResult.Error("Course not found !", $"The Category with id({request.Id}) was not found !", HttpStatusCode.NotFound);
            }

            hasCourse.Name = request.Name;
            hasCourse.Description = request.Description;
            hasCourse.Price = request.Price;
            hasCourse.Picture = request.Picture;
            hasCourse.CategoryId = request.CategoryId;

            context.Courses.Update(hasCourse);

            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
