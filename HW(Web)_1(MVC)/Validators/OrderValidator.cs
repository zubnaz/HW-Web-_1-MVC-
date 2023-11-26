using DataInfo.Data.Entitys;
using FluentValidation;

namespace HW_Web__1_MVC_.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.AutoId).NotNull();
        }
    }
}
