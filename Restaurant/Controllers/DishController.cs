using AutoMapper;
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
	/// CRUD контроллер по работе с блюдами
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = $"{nameof(Dish)}")]
	public class DishController : ControllerBase
	{
		private readonly AppContext appContext;
		private readonly IMapper mapper;
		private readonly IDishService dishService;
		private readonly IValidationService validationService;

		/// <summary>
		/// ctor
		/// </summary>
		public DishController(AppContext appContext, IMapper mapper, IDishService dishService, IValidationService validationService)
		{
			this.appContext = appContext;
			this.mapper = mapper;
			this.validationService = validationService;
			this.dishService = dishService;
		}

		/// <summary>
		/// Получает список блюд
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(typeof(IReadOnlyCollection<DishApiModel>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
		{
			var items = await dishService.GetAllDishes(cancellationToken);
			var result = mapper.Map<List<DishApiModel>>(items);
			return Ok(result);
		}

		/// <summary>
		/// Получает блюдо по id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		[HttpGet("{id:guid}")]
		//[ProducesNotFoundAttribute()]
		[ProducesResponseType(typeof(DishApiModel), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
		{
			var result = await dishService.GetDishById(id, cancellationToken);
			return Ok(mapper.Map<DishApiModel>(result));
		}

		/// <summary>
		/// Добавление нового блюда
		/// </summary>
		/// <param name="model"></param>
		/// <param name="cancellationToken"></param>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		//[ProducesResponseType(typeof(ErrorValidationModel), StatusCodes.Status406NotAcceptable)]
		public async Task<IActionResult> Add(AddDishApiModel model, CancellationToken cancellationToken)
		{
			var entity = mapper.Map<AddDishModel>(model);
			validationService.Validate(entity);
			await dishService.AddDish(entity, cancellationToken);
			return NoContent();
		}

		/// <summary>
		/// Редактирование блюда по id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		[HttpPut("{id:guid}")]
		//[ProducesResponseType(typeof(ErrorValidationModel), StatusCodes.Status406NotAcceptable)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Edit(Guid id, AddDishApiModel request, CancellationToken cancellationToken)
		{
			var model = mapper.Map<DishModel>(request);
			model.Id = id;

			await dishService.EditDish(model, cancellationToken);
			return NoContent();
		}

		/// <summary>
		/// Удаляет блюдо по id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="cancellationToken"></param>
		[HttpDelete("{id:guid}")]
		//[ProducesNotFoundAttribute()]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
		{
			await dishService.DeleteDish(id, cancellationToken);
			return NoContent();
		}
	}

}
