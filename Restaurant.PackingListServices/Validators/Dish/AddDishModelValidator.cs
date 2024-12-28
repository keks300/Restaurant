using FluentValidation;
using Restaurant.PackingListServices.Contracts.Model;
using Restaurant.PackingListServices.Contracts.Service;

namespace Restaurant.PackingListServices.Validators.Dish
{
	/// <summary>
	/// 
	/// </summary>
	public class AddDishModelValidator : AbstractValidator<AddDishModel>
	{
		private const int MaxDataBaseString = 200;
		private const int MinDataBaseString = 3;
		private const decimal MinPrice = 20;
		private const decimal MaxPrice = 25000;
		/// <summary>
		/// ctor
		/// </summary>
		public AddDishModelValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.Length(MinDataBaseString, MaxDataBaseString)
				.WithMessage("Название блюда не может быть пустым.");

			RuleFor(x => x.Description)
				.NotEmpty()
				.Length(MinDataBaseString, MaxDataBaseString)
				.WithMessage($"Описание не может быть длиннее {MaxDataBaseString} символов.");

			RuleFor(x => x.Price)
				.GreaterThanOrEqualTo(MinPrice).WithMessage($"Цена должна быть не меньше {MinPrice}.")
				.LessThanOrEqualTo(MaxPrice).WithMessage($"Цена не может быть больше {MaxPrice}.");
		}
	}
}
