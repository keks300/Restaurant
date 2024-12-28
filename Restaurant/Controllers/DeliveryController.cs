using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Contracts.Model;
using Restaurant.Model;
using Restaurant.Models;
using Restaurant.PackingListServices.Contracts.Model;
using Restaurant.PackingListServices.Contracts.Service;
using Restaurant.PackingListServices.Service;
using Restaurant.PackingListServices.ValidationService;
using Restaurant.Produces;
using AppContext = Restaurant.Context.AppContext;


namespace Restaurant.Controllers
{
	/// <summary>
	/// CRUD контроллер по работе с данными доставки
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = $"{nameof(Delivery)}")]
	public class DeliveryController : ControllerBase
	{
		private readonly AppContext appContext;
		private readonly IDeliveryService deliveryService;
		private readonly IMapper mapper;
		private readonly IValidationService validationService;

		/// <summary>
		/// ctor
		/// </summary>
		public DeliveryController(AppContext appContext, IDeliveryService deliveryService, IMapper mapper, IValidationService validationService)
		{
			this.appContext = appContext;
			this.deliveryService = deliveryService;
			this.mapper = mapper;
			this.validationService = validationService;
		}

		/// <summary>
		/// Получает список данных для доставки
		/// </summary>
		[HttpGet]
		[ProducesResponseType(typeof(IReadOnlyCollection<DeliveryApiModel>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAllDelivery(CancellationToken cancellationToken)
		{
			var items = await deliveryService.GetAllDelivery(cancellationToken);
			var result = mapper.Map<List<DeliveryApiModel>>(items);
			return Ok(result);
		}

		/// <summary>
		/// Получает данные для доставки по id
		/// </summary>
		[HttpGet("{id:guid}")]
		[ProducesNotFound()]
		[ProducesResponseType(typeof(DeliveryApiModel), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetDeliveryById(Guid id, CancellationToken cancellationToken)
		{
			var result = await deliveryService.GetDeliveryById(id, cancellationToken);
			return Ok(mapper.Map<DeliveryApiModel>(result));
		}

		/// <summary>
		/// Добавление новых данных для доставки
		/// </summary>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(typeof(ErrorValidationModel), StatusCodes.Status406NotAcceptable)]
		public async Task<IActionResult> AddDelivery(AddDeliveryApiModel model, CancellationToken cancellationToken)
		{
			var entity = mapper.Map<AddDeliveryModel>(model);
			validationService.Validate(entity);
			await deliveryService.AddDelivery(entity, cancellationToken);
			return NoContent();
		}

		/// <summary>
		/// Редактирование данных для доставки по id
		/// </summary>
		/// <param name="id"></param>
		[HttpPut("{id:guid}")]
		[ProducesResponseType(typeof(ErrorValidationModel), StatusCodes.Status406NotAcceptable)]
		public async Task<IActionResult> EditDelivery(Guid id, AddDeliveryApiModel request, CancellationToken cancellationToken)
		{
			var model = mapper.Map<DeliveryModel>(request);
			model.Id = id;
			validationService.Validate(model);
			await deliveryService.EditDelivery(model, cancellationToken);
			return NoContent();
		}

		/// <summary>
		/// Удаляет данные для доставки по id
		/// </summary>
		[HttpDelete("{id:guid}")]
		[ProducesNotFound()]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> DeleteDelivery(Guid id, CancellationToken cancellationToken)
		{
			await deliveryService.DeleteDelivery(id, cancellationToken);
			return NoContent();
		}
	}
}