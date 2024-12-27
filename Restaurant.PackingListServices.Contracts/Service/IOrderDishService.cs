using Restaurant.PackingListServices.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.PackingListServices.Contracts.Service
{
	/// <summary>
	/// Сервис по управлению <see cref="OrderDishModel"/>
	/// </summary>
	public interface IOrderDishService
	{
		/// <summary>
		/// Добавляет блюда в заказ
		/// </summary>
		Task AddDishesToOrder(Guid orderId, List<OrderDishModel> dishes, CancellationToken cancellationToken);

		/// <summary>
		/// Редактирует блюда в заказе
		/// </summary>
		Task EditDishesInOrder(Guid orderId, List<OrderDishModel> dishes, CancellationToken cancellationToken);

		/// <summary>
		/// Удаляет блюда в заказе
		/// </summary>
		Task DeleteDishesFromOrder(Guid orderId, List<Guid> dishIds, CancellationToken cancellationToken);

		/// <summary>
		/// Получает блюда в заказе
		/// </summary>
		Task<List<OrderDishModel>> GetDishesByOrderId(Guid orderId, CancellationToken cancellationToken);
	}
}
