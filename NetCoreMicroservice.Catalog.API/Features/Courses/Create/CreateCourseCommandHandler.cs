using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetCoreMicroservice.Catalog.API.Repository;
using NetCoreMicroservice.Shared;
using System.Net;

namespace NetCoreMicroservice.Catalog.API.Features.Courses.Create
{
    public class CreateCourseCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<CreateCourseCommand, ServiceResult<Guid>>
    {
        public async Task<ServiceResult<Guid>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {

            var hasCategory = await context.Categories.AnyAsync(x=> x.Id == request.CategoryId, cancellationToken);


            if (hasCategory) 
            {
                return ServiceResult<Guid>.Error("Category not found !",$"The Category with id({request.CategoryId}) was not found !", HttpStatusCode.NotFound);
            }

            var hasName = await context.Courses.AnyAsync(x=>x.Name == request.Name, cancellationToken);

            if (hasName)
            {
                return ServiceResult<Guid>.Error("Course already exist!", $"The Course with name({request.Name}) already exist !", HttpStatusCode.BadRequest);
            }

            var newCourse = mapper.Map<Course>(request);

            newCourse.Created = DateTime.Now;

            newCourse.Id = NewId.NextSequentialGuid(); // index performance

            newCourse.Feature = new Feature
            {
                Duration = 10, // calculate by course video
                EducatorFullName = "Ahmet Yılmaz", // get by token payload
                Rating = 0
            };

            context.Courses.Add(newCourse);

            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult<Guid>.SuccessAsCreated(newCourse.Id, $"/api/courses/{newCourse.Id}");
        }
    }
}
