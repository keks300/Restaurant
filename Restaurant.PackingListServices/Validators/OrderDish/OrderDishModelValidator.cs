using FluentValidation;
using Restaurant.PackingListServices.Contracts.Model;
using Restaurant.PackingListServices.Validators.Order;

namespace WebApiTest.PackingListServices.Validators.OrderDish
{
	/// <summary>
	/// Валидатор для <see cref="OrderDishModel"/>
	/// </summary>
	public class OrderDishModelValidator : AbstractValidator<OrderDishModel>
	{

		/// <summary>
		/// ctor
		/// </summary>
		public OrderDishModelValidator()
		{
			RuleFor(x => x.DishId).NotEmpty();
			RuleFor(x => x.Quantity)
				.GreaterThanOrEqualTo(1)
				.LessThanOrEqualTo(99)
				.WithMessage("Количество должно быть в пределах от 1 до 99");
		}
	}
}
