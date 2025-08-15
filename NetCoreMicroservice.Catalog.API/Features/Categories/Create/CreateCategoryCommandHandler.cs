using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetCoreMicroservice.Catalog.API.Repository;
using NetCoreMicroservice.Shared;
using System.Net;

namespace NetCoreMicroservice.Catalog.API.Features.Categories.Create
{
    public class CreateCategoryCommandHandler(AppDbContext context) : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
    {
        public async Task<ServiceResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existCategory = await context.Categories.AnyAsync(x => x.Name == request.Name, cancellationToken = cancellationToken);

            if (existCategory)
            {
                ServiceResult<CreateCategoryResponse>.Error("Category name already exist.",$"The name {request.Name} already exist ", HttpStatusCode.BadRequest);
            }

            var category = new Category
            {
                Name = request.Name,
                Id = NewId.NextSequentialGuid(),
            };

            await context.Categories.AddAsync(category, cancellationToken); //Kontrol et

            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(new CreateCategoryResponse(category.Id),"<empty>");
        }
    }
}
