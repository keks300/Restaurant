using FluentValidation;
using Restaurant.PackingListServices.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.PackingListServices.Validators.Customer
{
	public class AddCustomerModelValidator: AbstractValidator<AddCustomerModel>
	{
		private const int MaximumPhoneNumberLength = 12;
		private const int MinPhoneNumberLength = 11;
		private const int MaxLengthFullName = 30;

		public AddCustomerModelValidator()
        {
			RuleFor(x => x.Phone).NotEmpty().Length(MinPhoneNumberLength, MaximumPhoneNumberLength);
			RuleFor(x => x.FullName).NotEmpty().MaximumLength(MaxLengthFullName);
			
			// Валидация для почты
			RuleFor(x => x.Email)
				.NotEmpty()
				.MaximumLength(MaxLengthFullName)
				.Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("Некорректный формат электронной почты");
		}
    }
}
