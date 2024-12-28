using FluentValidation;
using Restaurant.PackingListServices.Contracts.Model;

namespace Restaurant.PackingListServices.Validators.Order
{
    /// <summary>
    /// 
    /// </summary>
    public class AddOrderModelValidator : AbstractValidator<AddOrderModel>
    {
        /// <summary>
        /// ctor
        /// </summary>
        public AddOrderModelValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("OrderId не может быть пустым.");
            RuleFor(x => x.Dishes).NotEmpty();
		}
    }
}
