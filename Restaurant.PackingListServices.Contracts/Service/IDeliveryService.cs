using Restaurant.PackingListServices.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.PackingListServices.Contracts.Service
{
	/// <summary>
	/// Сервис по управлению <see cref="DeliveryModel"/>
	/// </summary>
	public interface IDeliveryService
	{
		/// <summary>
		/// Получает список данных для доставки
		/// </summary>
		Task<IReadOnlyCollection<DeliveryModel>> GetAllDelivery(CancellationToken cancellationToken);

		/// <summary>
		/// Получает данные для доставки по id
		/// </summary>
		Task<DeliveryModel> GetDeliveryById(Guid id, CancellationToken cancellationToken);

		/// <summary>
		/// Добавление новых данных для доставки
		/// </summary>
		Task<Guid> AddDelivery(AddDeliveryModel model, CancellationToken cancellationToken);

		/// <summary>
		/// Редактирование данных для доставки по id
		/// </summary>
		Task EditDelivery(DeliveryModel model, CancellationToken cancellationToken);

		/// <summary>
		/// Удаляет данные для доставки по id
		/// </summary>
		Task DeleteDelivery(Guid id, CancellationToken cancellationToken);
	}
}
