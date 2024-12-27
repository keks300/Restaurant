using Restaurant.PackingListServices.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.PackingListServices.Contracts.Service
{
	/// <summary>
	/// Сервис по управлению <see cref="DishModel"/>
	/// </summary>
	public interface IDishService
    {
		/// <summary>
		/// Получает список блюд
		/// </summary>
		Task<IReadOnlyCollection<DishModel>> GetAllDishes(CancellationToken cancellationToken);

		/// <summary>
		/// Получает блюдо по id
		/// </summary>>
		Task<DishModel> GetDishById(Guid id, CancellationToken cancellationToken);

		/// <summary>
		/// Получает блюдо по id
		/// </summary>
		Task<Guid> AddDish(AddDishModel model, CancellationToken cancellationToken);

		/// <summary>
		/// Добавление нового блюда
		/// </summary>
		Task EditDish(DishModel model, CancellationToken cancellationToken);

		/// <summary>
		/// Редактирование блюда по id
		/// </summary>
		Task DeleteDish(Guid id, CancellationToken cancellationToken);
    }
}
