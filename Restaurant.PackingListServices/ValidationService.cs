using FluentValidation;
using Restaurant.Contracts.Model;
using Restaurant.PackingListServices.Contracts.Model;
using Restaurant.PackingListServices.Exceptions;
using Restaurant.PackingListServices.ValidationService;
using Restaurant.PackingListServices.Validators.Customer;
using Restaurant.PackingListServices.Validators.Delivery;
using Restaurant.PackingListServices.Validators.Dish;
using Restaurant.PackingListServices.Validators.Order;
using WebApiTest.PackingListServices.Validators.Order;
using WebApiTest.PackingListServices.Validators.OrderDish;

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
            
            validators.Add(typeof(OrderModel), new OrderModelValidator());
            validators.Add(typeof(AddOrderModel), new AddOrderModelValidator());            
            
            validators.Add(typeof(DeliveryModel), new DeliveryModelValidator());
            validators.Add(typeof(AddDeliveryModel), new AddDeliveryModelValidator());

            validators.Add(typeof(OrderDishModel), new OrderDishModelValidator());
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
