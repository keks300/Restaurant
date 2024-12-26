using FluentValidation;
using Restaurant.PackingListServices.Contracts.Model;
using Restaurant.PackingListServices.Exceptions;
using Restaurant.PackingListServices.ValidationService;
using Restaurant.PackingListServices.Validators.Customer;
using Restaurant.PackingListServices.Validators.Dish;

namespace WebApiTest.PackingListServices
{
	/// <summary>
	/// 
	/// </summary>
	public class ValidationService : IValidationService
    {
        private readonly Dictionary<Type, IValidator> validators = new();

        /// <summary>
        /// ctor
        /// </summary>
        public ValidationService()
        {
            validators.Add(typeof(DishModel), new DishModelValidator());
            validators.Add(typeof(AddDishModel), new AddDishModelValidator());            
            validators.Add(typeof(CustomerModel), new CustomerModelValidator());
            validators.Add(typeof(AddCustomerModel), new AddCustomerModelValidator());
        }
        public void Validate<TModel>(TModel model)
        {
            var modeltype = typeof(TModel);
            if (validators.TryGetValue(modeltype, out var validator))
            {
                var context = new ValidationContext<TModel>(model);
                var validarotResult = validator.Validate(context);

                if (!validarotResult.IsValid)
                {
                    throw new ValidateModelException(validarotResult.Errors.Select(x =>
                        (x.PropertyName, x.ErrorMessage)));
                }
            }
            else
            {
                throw new OperationModelException($"Не удалось найти валидатор для типа {modeltype}");
            }
        }
    }
}
