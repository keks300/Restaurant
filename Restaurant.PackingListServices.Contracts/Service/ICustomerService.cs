using Restaurant.PackingListServices.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.PackingListServices.Contracts.Service
{
	public interface ICustomerService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<IReadOnlyCollection<CustomerModel>> GetAllCustomers(CancellationToken cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<CustomerModel> GetCustomerById(Guid id, CancellationToken cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<Guid> AddCustomer(AddCustomerModel model, CancellationToken cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task EditCustomer(CustomerModel model, CancellationToken cancellationToken);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task DeleteCustomer(Guid id, CancellationToken cancellationToken);
	}
}
