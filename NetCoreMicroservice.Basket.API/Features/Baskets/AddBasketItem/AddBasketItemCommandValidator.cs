using FluentValidation;

namespace NetCoreMicroservice.Basket.API.Features.Baskets.AddBasketItem
{
    public class AddBasketItemCommandValidator : AbstractValidator<AddBasketItemCommand>
    {
        public AddBasketItemCommandValidator()
        {
            RuleFor(x =>x.CourseId).NotEmpty().WithMessage("Course ID is required.");
            RuleFor(x =>x.CourseName).NotEmpty().WithMessage("Course name cannot be null.");
            RuleFor(x =>x.CoursePrice).GreaterThan(0).WithMessage("Course price and must be greater than 0.");
        }
    }
}
