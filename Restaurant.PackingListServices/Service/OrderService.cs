using AutoMapper;
using Restaurant.Context.Contracts;
using Restaurant.Contracts.Model;
using Restaurant.PackingListServices.Contracts.Model;
using Restaurant.PackingListServices.Contracts.Service;
using Restaurant.PackingListServices.Exceptions;
using Restaurant.PackingListServices.Service;
using Restaurant.Repositories.Contracts;


namespace Restaurant.PackingListServices.Service
{
	/// <inheritdoc cref="IOrderService"/>
	public class OrderService : IOrderService
	{
		private readonly IMapper mapper;
		private readonly IReadRepository<Order> orderReadRepository;
		private readonly IWriteRepository<Order> orderWriteRepository;
		private readonly IUnitOfWork unitOfWork;
		private readonly IOrderDishService orderDishService;
		private readonly IOrderAmountCalculator orderAmountCalculator;

		/// <summary>
		/// ctor
		/// </summary>
		public OrderService(
			IMapper mapper,
			IReadRepository<Order> orderReadRepository,
			IWriteRepository<Order> orderWriteRepository,
			IUnitOfWork unitOfWork,
			IOrderDishService orderDishService,
			IOrderAmountCalculator orderAmountCalculator)
		{
			this.mapper = mapper;
			this.orderReadRepository = orderReadRepository;
			this.orderWriteRepository = orderWriteRepository;
			this.unitOfWork = unitOfWork;
			this.orderDishService = orderDishService;
			this.orderAmountCalculator = orderAmountCalculator;
		}

		/// <inheritdoc/>
		public async Task<Guid> AddOrder(AddOrderModel model, CancellationToken cancellationToken)
		{
			var order = mapper.Map<Order>(model);

			order.TotalAmount = await orderAmountCalculator.CalculateTotalAmount(model.Dishes, cancellationToken);

			orderWriteRepository.Add(order);
			await unitOfWork.CommitAsync(cancellationToken);

			if (model.Dishes != null && model.Dishes.Count > 0)
			{
				await orderDishService.AddDishesToOrder(order.Id, model.Dishes, cancellationToken);
			}

			return order.Id;
		}

		/// <inheritdoc/>
		public async Task<OrderModel> GetOrderById(Guid id, CancellationToken cancellationToken)
		{
			var order = await orderReadRepository.GetById(id, cancellationToken);
			if (order == null)
			{
				throw new KeyNotFoundException($"Order with ID {id} not found.");
			}

			var dishes = await orderDishService.GetDishesByOrderId(id, cancellationToken);
			var orderModel = mapper.Map<OrderModel>(order);
			orderModel.Dishes = dishes;
			return orderModel;
		}

		/// <inheritdoc/>
		public async Task<IReadOnlyCollection<OrderModel>> GetAllOrders(CancellationToken cancellationToken)
		{
			var orders = await orderReadRepository.GetAll(cancellationToken);

			var orderModels = new List<OrderModel>();
			foreach (var order in orders)
			{
				var orderModel = mapper.Map<OrderModel>(order);
				var dishes = await orderDishService.GetDishesByOrderId(order.Id, cancellationToken);
				orderModel.Dishes = dishes;
				orderModels.Add(orderModel);
			}

			return orderModels;
		}

		/// <inheritdoc/>
		public async Task EditOrder(OrderModel model, CancellationToken cancellationToken)
		{
			var existingOrder = await orderReadRepository.GetById(model.Id, cancellationToken);
			if (existingOrder == null)
			{
				throw new NotFoundModelException(model.Id);
			}

			existingOrder.CustomerId = model.CustomerId;
			existingOrder.TotalAmount = await orderAmountCalculator.CalculateTotalAmount(model.Dishes, cancellationToken);
			orderWriteRepository.Update(existingOrder);

			if (model.Dishes != null && model.Dishes.Count > 0)
			{
				await orderDishService.EditDishesInOrder(model.Id, model.Dishes, cancellationToken);
			}




			await unitOfWork.CommitAsync(cancellationToken);
		}

		/// <inheritdoc/>
		public async Task DeleteOrder(Guid id, CancellationToken cancellationToken)
		{
			var order = await orderReadRepository.GetById(id, cancellationToken);
			if (order == null)
			{
				throw new KeyNotFoundException($"Order with ID {id} not found.");
			}

			await orderDishService.DeleteDishesFromOrder(id, new List<Guid>(), cancellationToken);
			orderWriteRepository.Delete(order);

			await unitOfWork.CommitAsync(cancellationToken);
		}
	}
}
