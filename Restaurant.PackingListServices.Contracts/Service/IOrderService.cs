using Restaurant.PackingListServices.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.PackingListServices.Contracts.Service
{
	/// <summary>
	/// Сервис по управлению <see cref="OrderModel"/>
	/// </summary>
	public interface IOrderService
	{
		/// <summary>
		/// Получает список заказов
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<IReadOnlyCollection<OrderModel>> GetAllOrders(CancellationToken cancellationToken);

		/// <summary>
		/// Получает заказ по id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<OrderModel> GetOrderById(Guid id, CancellationToken cancellationToken);

		/// <summary>
		/// Добавление нового заказа
		/// </summary>
		/// <param name="model"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<Guid> AddOrder(AddOrderModel model, CancellationToken cancellationToken);

		/// <summary>
		/// Редактирование заказа по id
		/// </summary>
		/// <param name="model"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task EditOrder(OrderModel model, CancellationToken cancellationToken);

		/// <summary>
		/// Удаляет заказ по id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task DeleteOrder(Guid id, CancellationToken cancellationToken);
	}
}
