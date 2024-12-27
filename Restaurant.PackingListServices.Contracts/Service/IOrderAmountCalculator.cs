using Restaurant.PackingListServices.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.PackingListServices.Contracts.Service
{
	/// <summary>
	/// Сервис для высчитывания конечной цены
	/// </summary>
	public interface IOrderAmountCalculator
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dishes"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<decimal> CalculateTotalAmount(IEnumerable<OrderDishModel> dishes, CancellationToken cancellationToken);
	}
}
