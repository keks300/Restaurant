using Restaurant.PackingListServices.Validators.Dish;
using FluentValidation;
using Restaurant.PackingListServices.Contracts.Model;


namespace Restaurant.PackingListServices.Validators.Delivery
{
	/// <summary>
	/// Валидатор для <see cref="DeliveryModel"/>
	/// </summary>
	public class DeliveryModelValidator : AbstractValidator<DeliveryModel>
	{
		/// <summary>
		/// ctor
		/// </summary>
        public DeliveryModelValidator()
        {
			Include(new AddDeliveryModelValidator());
			RuleFor(x => x.Id).NotEmpty();
		}
    }
}
