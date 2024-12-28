using FluentValidation;
using Restaurant.PackingListServices.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.PackingListServices.Validators.Delivery
{
	/// <summary>
	/// Валидатор для <see cref="AddDeliveryModel"/>
	/// </summary>
	public class AddDeliveryModelValidator : AbstractValidator<AddDeliveryModel>
	{
		/// <summary>
		/// ctor
		/// </summary>
        public AddDeliveryModelValidator()
        {
			RuleFor(x => x.OrderId)
				.NotEmpty().WithMessage("OrderId не может быть пустым.");

			RuleFor(x => x.DeliveryAddress)
				.NotEmpty().WithMessage("Адрес доставки не может быть пустым.")
				.MaximumLength(200).WithMessage("Адрес доставки не может быть длиннее 200 символов.");

			RuleFor(x => x.DeliveryDate)
				.NotEmpty().WithMessage("Дата доставки не может быть пустой.")
				.GreaterThan(DateTime.Now).WithMessage("Дата доставки должна быть в будущем.");

			RuleFor(x => x.Status)
				.IsInEnum().WithMessage("Некорректное значение статуса.")
				.NotEmpty().WithMessage("Статус не может быть пустым.");
		}
    }
}
