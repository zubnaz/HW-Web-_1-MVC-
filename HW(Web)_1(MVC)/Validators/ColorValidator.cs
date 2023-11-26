using FluentValidation;

namespace HW_Web__1_MVC_.Validators
{
    public class ColorValidator : AbstractValidator<DataInfo.Data.Entitys.Color>
    {
        public ColorValidator()
        {
            RuleFor(x => x.ColorName).NotNull().WithMessage("{PropertyName} not valid");
        }
    }
}
