using Restaurant.Context.Contracts;
using Restaurant.Contracts.Model;
using Restaurant.PackingListServices.Contracts.Model;
using Restaurant.PackingListServices.Contracts.Service;
using Restaurant.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.PackingListServices.Service
{
	public class OrderDishService : IOrderDishService
	{
		private readonly IWriteRepository<OrderDish> orderDishWriteRepository;
		private readonly IReadRepository<OrderDish> orderDishReadRepository;
		private readonly IUnitOfWork unitOfWork;

		public OrderDishService(
			IWriteRepository<OrderDish> orderDishWriteRepository,
			IReadRepository<OrderDish> orderDishReadRepository,
			IUnitOfWork unitOfWork)
		{
			this.orderDishWriteRepository = orderDishWriteRepository;
			this.orderDishReadRepository = orderDishReadRepository;
			this.unitOfWork = unitOfWork;
		}

		public async Task AddDishesToOrder(Guid orderId, List<OrderDishModel> dishes, CancellationToken cancellationToken)
		{
			foreach (var dish in dishes)
			{
				if (dish.Quantity > 0)
				{
					var orderDish = new OrderDish
					{
						OrderId = orderId,
						DishId = dish.DishId,
						Quantity = dish.Quantity
					};

					orderDishWriteRepository.Add(orderDish);
				}
			}
			await unitOfWork.CommitAsync(cancellationToken); // Сохраняем изменения через UnitOfWork
		}

		public async Task EditDishesInOrder(Guid orderId, List<OrderDishModel> dishes, CancellationToken cancellationToken)
		{
			// Получаем все текущие записи для заказа, отслеживаемые контекстом
			var orderDishes = await orderDishReadRepository
				.GetAll(cancellationToken);

			var existingDishes = orderDishes.Where(d => d.OrderId == orderId).ToList();

			if (existingDishes.Count != dishes.Count)
			{
				throw new InvalidOperationException("Количество блюд в заказе не совпадает с количеством предоставленных данных.");
			}

			for (int i = 0; i < existingDishes.Count; i++)
			{
				var dish = existingDishes[i];
				dish.DishId = dishes[i].DishId;
				dish.Quantity = dishes[i].Quantity;
			}

			// Все изменения уже отслеживаются контекстом,
			// поэтому вызываем только CommitAsync
			await unitOfWork.CommitAsync(cancellationToken);
		}

		public async Task DeleteDishesFromOrder(Guid orderId, List<Guid> dishIds, CancellationToken cancellationToken)
		{
			var existingDishes = await orderDishReadRepository
				.GetAll(cancellationToken);

			var dishesToDelete = existingDishes
				.Where(d => d.OrderId == orderId && dishIds.Contains(d.DishId))
				.ToList();

			foreach (var dish in existingDishes)
			{
				orderDishWriteRepository.Delete(dish);
			}

			await unitOfWork.CommitAsync(cancellationToken);
		}

		public async Task<List<OrderDishModel>> GetDishesByOrderId(Guid orderId, CancellationToken cancellationToken)
		{
			var dishes = await orderDishReadRepository
				.GetAll(cancellationToken);

			var orderDishes = dishes
				.Where(d => d.OrderId == orderId)
				.Select(d => new OrderDishModel
				{
					DishId = d.DishId,
					Quantity = d.Quantity,
					
				})
				.ToList();

			return orderDishes;
		}

		public async Task<IReadOnlyCollection<OrderDishModel>> GetAllDishesByOrderId(Guid orderId, CancellationToken cancellationToken)
		{
			var dishes = await orderDishReadRepository
				.GetAll(cancellationToken);

			var orderDishes = dishes
				.Where(d => d.OrderId == orderId)
				.Select(d => new OrderDishModel
				{
					DishId = d.DishId,
					Quantity = d.Quantity
				})
				.ToList();

			return orderDishes;
		}
	}
}
