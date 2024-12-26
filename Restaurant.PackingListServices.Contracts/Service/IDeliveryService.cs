using Restaurant.PackingListServices.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.PackingListServices.Contracts.Service
{
	public interface IDeliveryService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<IReadOnlyCollection<DeliveryModel>> GetAll(CancellationToken cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<DeliveryModel> GetById(Guid id, CancellationToken cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<Guid> Add(AddDeliveryModel model, CancellationToken cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task Edit(DeliveryModel model, CancellationToken cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task Delete(Guid id, CancellationToken cancellationToken);
	}
}
