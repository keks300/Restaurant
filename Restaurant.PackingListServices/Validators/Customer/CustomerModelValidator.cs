using FluentValidation;
using Restaurant.PackingListServices.Contracts.Model;
using Restaurant.PackingListServices.Validators.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.PackingListServices.Validators.Customer
{
	public class CustomerModelValidator : AbstractValidator<CustomerModel>
	{
       /// <summary>
       /// ctor
       /// </summary>
        public CustomerModelValidator()
        {
			Include(new AddCustomerModelValidator());
			RuleFor(x => x.Id).NotEmpty();
		}
    }
}
