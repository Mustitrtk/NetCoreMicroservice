using FluentValidation;

namespace NetCoreMicroservice.Discount.API.Features.Discount.CreateDiscount
{
    public class CreateDiscoundCommandValidator : AbstractValidator<CreateDiscountCommand>
    {
        public CreateDiscoundCommandValidator() 
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("{PropertyName} field required")
                .Length(10).WithMessage("{PropertyName} cannot be greater than 6 characters!");

            RuleFor(x => x.Rate)
                .NotEmpty().WithMessage("{PropertyName} field required")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100%")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0%");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("{PropertyName} field required");

            RuleFor(x => x.Expired)
                .NotEmpty().WithMessage("{PropertyName} field required")
                .GreaterThan(DateTime.Now).WithMessage("{PropertyName} must be greater than today");
        }
    }
}
