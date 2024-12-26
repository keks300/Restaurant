using FluentValidation;
using Restaurant.PackingListServices.Contracts.Model;
using Restaurant.PackingListServices.Validators.Order;

namespace WebApiTest.PackingListServices.Validators.Order
{
    /// <summary>
    /// Валидатор для <see cref="OrderModel"/>
    /// </summary>
    public class OrderModelValidator : AbstractValidator<OrderModel>
    {
        /// <summary>
        /// ctor
        /// </summary>
        public OrderModelValidator()
        {
            Include(new AddOrderModelValidator());
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
