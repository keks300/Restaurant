using Restaurant.Contracts.Model;
using Restaurant.Repositories;
using Restaurant.Repositories.Contracts;
using Restaurant.Repositories.OrderRepository;
using Restaurant.Repositories.OrderRepository.OrderDishRepository;

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
		public static void AddDishRepositoryServices(this IServiceCollection services)
		{
			services.AddScoped<IWriteRepository<Dish>, WriteRepository<Dish>>();
			services.AddScoped<IReadRepository<Dish>, ReadRepository<Dish>>();
		}

		/// <summary>
		/// Регистрация репозиториев для Customer.
		/// </summary>
		/// <param name="services"></param>
		public static void AddCustomerRepositoryServices(this IServiceCollection services)
		{
			services.AddScoped<IWriteRepository<Customer>, WriteRepository<Customer>>();
			services.AddScoped<IReadRepository<Customer>, ReadRepository<Customer>>();
		}

		/// <summary>
		/// Регистрация репозиториев для Order.
		/// </summary>
		/// <param name="services"></param>
		public static void AddOrderRepositoryServices(this IServiceCollection services)
		{
			services.AddScoped<IWriteRepository<Order>, WriteRepository<Order>>();
			services.AddScoped<IReadRepository<Order>, ReadRepository<Order>>();
		}

		/// <summary>
		/// Регистрация репозиториев для OrderDish.
		/// </summary>
		/// <param name="services"></param>
		public static void AddOrderDishRepositoryServices(this IServiceCollection services)
		{
			services.AddScoped<IWriteRepository<OrderDish>, WriteRepository<OrderDish>>();
			services.AddScoped<IReadRepository<OrderDish>, ReadRepository<OrderDish>>();
		}
	}


}
