using Restaurant.PackingListServices.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.PackingListServices.Contracts.Service
{
	/// <summary>
	/// Сервис по управлению <see cref="CustomerModel"/>
	/// </summary>
	public interface ICustomerService
	{
		/// <summary>
		/// Получает список покупателей
		/// </summary>
		Task<IReadOnlyCollection<CustomerModel>> GetAllCustomers(CancellationToken cancellationToken);

		/// <summary>
		/// Получает покупателя по id
		/// </summary>
		Task<CustomerModel> GetCustomerById(Guid id, CancellationToken cancellationToken);

		/// <summary>
		/// Добавление нового покупателя
		/// </summary>
		Task<Guid> AddCustomer(AddCustomerModel model, CancellationToken cancellationToken);

		/// <summary>
		/// Редактирование покупателя по id
		/// </summary>
		Task EditCustomer(CustomerModel model, CancellationToken cancellationToken);

		/// <summary>
		/// Удаляет покупателя по id
		/// </summary>
		Task DeleteCustomer(Guid id, CancellationToken cancellationToken);
	}
}
