using Restaurant.Contracts.Model;
using Restaurant.PackingListServices.Contracts.Model;
using Restaurant.PackingListServices.Contracts.Service;
using Restaurant.PackingListServices.Exceptions;
using Restaurant.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.PackingListServices.Service
{
	public class OrderAmountCalculator : IOrderAmountCalculator
	{
		private readonly IReadRepository<Dish> dishReadRepository;

		/// <summary>
		/// ctor
		/// </summary>
        public OrderAmountCalculator(IReadRepository<Dish> dishReadRepository)
        {
            this.dishReadRepository = dishReadRepository;
        }

        public async Task<decimal> CalculateTotalAmount(IEnumerable<OrderDishModel> dishes, CancellationToken cancellationToken)
		{
			decimal totalAmount = 0;

			foreach (var dishModel in dishes)
			{
				// Получаем блюдо по DishId
				var dish = await dishReadRepository.GetById(dishModel.DishId, cancellationToken);
				if (dish == null)
				{
					throw new NotFoundModelException(dishModel.DishId); // Если блюдо не найдено
				}

				// Добавляем стоимость блюда, умноженную на количество
				totalAmount += dish.Price * dishModel.Quantity;
			}

			return totalAmount;
		}
	}
}
