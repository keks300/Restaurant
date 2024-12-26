using Restaurant.PackingListServices.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.PackingListServices.Contracts.Service
{
	public interface IOrderDishService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderId"></param>
		/// <param name="dishes"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task AddDishesToOrder(Guid orderId, List<OrderDishModel> dishes, CancellationToken cancellationToken);
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderId"></param>
		/// <param name="dishes"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task EditDishesInOrder(Guid orderId, List<OrderDishModel> dishes, CancellationToken cancellationToken);
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderId"></param>
		/// <param name="dishIds"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task DeleteDishesFromOrder(Guid orderId, List<Guid> dishIds, CancellationToken cancellationToken);
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderId"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<List<OrderDishModel>> GetDishesByOrderId(Guid orderId, CancellationToken cancellationToken);
		
		
		//Task<IReadOnlyCollection<OrderDishModel>> GetAllDishesByOrderId(Guid orderId, CancellationToken cancellationToken); // Новый метод
	}
}
