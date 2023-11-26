using DataInfo.Data.Entitys;
using FluentValidation;

namespace HW_Web__1_MVC_.Validators
{
    public class AutoValidator : AbstractValidator<Auto>
    {
        public AutoValidator()
        {
            RuleFor(x => x.Mark).NotNull().WithMessage("{PropertyName} not valid");
            RuleFor(x => x.Model).NotNull().WithMessage("{PropertyName} not valid"); ;
            RuleFor(x => x.Price).NotNull().InclusiveBetween(0, 100000).WithMessage("{PropertyName} must be in the range 0 to 100000");
            RuleFor(x => x.Year).NotNull().InclusiveBetween(1900, 2023).WithMessage("{PropertyName} must be in the range 1900 to 2023");
            RuleFor(x => x.Image).Must(ValidateUri).WithMessage("{PropertyName} not valid");
            RuleFor(x => x.ColorId).NotEqual(0).WithMessage("Color not valid");
        }
        public bool ValidateUri(string? uri)
        {
            // just so the validation passes if the uri is not required / nullable
            if (string.IsNullOrEmpty(uri))
            {
                return true;
            }
            return Uri.TryCreate(uri, UriKind.Absolute, out _);
        }
    }
}
