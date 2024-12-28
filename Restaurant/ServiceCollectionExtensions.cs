using Restaurant.Common.Abstractions;
using Restaurant.Common;
using Restaurant.Contracts.Model;
using Restaurant.PackingListServices.Contracts.Service;
using Restaurant.PackingListServices.Service;
using Restaurant.PackingListServices.ValidationService;
using Restaurant.Repositories;
using Restaurant.Repositories.Contracts;
using WebApiTest.PackingListServices;

namespace Restaurant
{
	/// <summary>
	/// 
	/// </summary>
	public static class ServiceCollectionExtensions
	{
		/// <summary>
		/// Регистрация репозиториев для Dish.
		/// </summary>
		/// <param name="services"></param>
		public static void AddRepositoryServices(this IServiceCollection services)
		{
			services.AddScoped<IWriteRepository<Dish>, WriteRepository<Dish>>();
			services.AddScoped<IReadRepository<Dish>, ReadRepository<Dish>>();

			services.AddScoped<IWriteRepository<Customer>, WriteRepository<Customer>>();
			services.AddScoped<IReadRepository<Customer>, ReadRepository<Customer>>();

			services.AddScoped<IWriteRepository<Order>, WriteRepository<Order>>();
			services.AddScoped<IReadRepository<Order>, ReadRepository<Order>>();

			services.AddScoped<IWriteRepository<OrderDish>, WriteRepository<OrderDish>>();
			services.AddScoped<IReadRepository<OrderDish>, ReadRepository<OrderDish>>();
			
			services.AddScoped<IWriteRepository<Delivery>, WriteRepository<Delivery>>();
			services.AddScoped<IReadRepository<Delivery>, ReadRepository<Delivery>>();
		}

		/// <summary>
		/// Регистрация всех необходимых сервисов
		/// </summary>
		/// <param name="services"></param>
		public static void AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<IDishService, DishService>();
			services.AddScoped<ICustomerService, CustomerService>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddScoped<IOrderDishService, OrderDishService>();
			services.AddScoped<IDeliveryService, DeliveryService>();
			services.AddScoped<IOrderAmountCalculator, OrderAmountCalculator>();
			services.AddSingleton<IValidationService, ValidationService>();
			services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
		}
	}


}
