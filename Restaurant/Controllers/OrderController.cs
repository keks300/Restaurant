﻿using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Contracts.Model;
using Restaurant.Model;
using Restaurant.PackingListServices.Contracts.Model;
using Restaurant.PackingListServices.Contracts.Service;
using Restaurant.PackingListServices.ValidationService;
using AppContext = Restaurant.Context.AppContext;

namespace Restaurant.Controllers
{
	/// <summary>
	/// CRUD контроллер по работе с заказами
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = $"{nameof(Order)}")]
	public class OrderController : ControllerBase
	{
		private readonly AppContext appContext;
		private readonly IOrderService orderService;
		private readonly IMapper mapper;
		private readonly IValidationService validationService;

		/// <summary>
		/// ctor
		/// </summary>
		/// <param name="appContext"></param>
		/// <param name="orderService"></param>
		/// <param name="mapper"></param>
		/// <param name="validationService"></param>
		public OrderController(AppContext appContext, IOrderService orderService, IMapper mapper, IValidationService validationService)
		{
			this.appContext = appContext;
			this.orderService = orderService;
			this.mapper = mapper;
			this.validationService = validationService;
		}

		/// <summary>
		/// Получает список заказов
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(typeof(IReadOnlyCollection<OrderApiModel>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAllOrders(CancellationToken cancellationToken)
		{
			var orders = await orderService.GetAllOrders(cancellationToken);
			return Ok(orders);
		}

		/// <summary>
		/// Получает заказ по id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		[HttpGet("{id:guid}")]
		//[ProducesNotFoundAttribute()]
		[ProducesResponseType(typeof(OrderApiModel), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetOrderById(Guid id, CancellationToken cancellationToken)
		{
			var order = await orderService.GetOrderById(id, cancellationToken);
			return Ok(order);
		}

		/// <summary>
		/// Добавление нового заказа
		/// </summary>
		/// <param name="model"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		//[ProducesResponseType(typeof(ErrorValidationModel), StatusCodes.Status406NotAcceptable)]
		public async Task<IActionResult> AddOrder(AddOrderApiModel model, CancellationToken cancellationToken)
		{
			var addOrderModel = mapper.Map<AddOrderModel>(model);
			var orderId = await orderService.AddOrder(addOrderModel, cancellationToken);
			return NoContent();
		}

		/// <summary>
		/// Редактирование заказа по id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		[HttpPut("{id:guid}")]
		//[ProducesResponseType(typeof(ErrorValidationModel), StatusCodes.Status406NotAcceptable)]
		public async Task<IActionResult> EditOrder(Guid id, AddOrderApiModel request, CancellationToken cancellationToken)
		{
			var model = mapper.Map<OrderModel>(request);
			model.Id = id;
			await orderService.EditOrder(model, cancellationToken);
			return NoContent();
		}

		/// <summary>
		/// Удаляет заказ по id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		[HttpDelete("{id:guid}")]
		//[ProducesNotFoundAttribute()]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> DeleteOrder(Guid id, CancellationToken cancellationToken)
		{
			await orderService.DeleteOrder(id, cancellationToken);
			return NoContent();
		}
	}
}