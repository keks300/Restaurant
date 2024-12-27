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
	/// CRUD контроллер по работе с покупателями
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = $"{nameof(Customer)}")]
	public class CustomerController : ControllerBase
	{
		private readonly AppContext appContext;
		private readonly ICustomerService customerService;
		private readonly IMapper mapper;
		private readonly IValidationService validationService;

		/// <summary>
		/// ctor
		/// </summary>
		public CustomerController(AppContext appContext, ICustomerService customerService, IMapper mapper, IValidationService validationService)
        {
            this.appContext = appContext;
			this.customerService = customerService;
			this.mapper = mapper;
			this.validationService = validationService;
        }

		/// <summary>
		/// Получает список покупателей
		/// </summary>
		[HttpGet]
		[ProducesResponseType(typeof(IReadOnlyCollection<CustomerApiModel>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
		{
			var items = await customerService.GetAllCustomers(cancellationToken);
			var result = mapper.Map<List<CustomerApiModel>>(items);
			return Ok(result);
		}

		/// <summary>
		/// Получает покупателя по id
		/// </summary>
		[HttpGet("{id:guid}")]
		[ProducesNotFound()]
		[ProducesResponseType(typeof(CustomerApiModel), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
		{
			var result = await customerService.GetCustomerById(id, cancellationToken);
			return Ok(mapper.Map<CustomerApiModel>(result));
		}

		/// <summary>
		/// Добавление нового покупателя
		/// </summary>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(typeof(ErrorValidationModel), StatusCodes.Status406NotAcceptable)]
		public async Task<IActionResult> Add(AddCustomerApiModel model, CancellationToken cancellationToken)
		{
			var entity = mapper.Map<AddCustomerModel>(model);
			validationService.Validate(entity);
			await customerService.AddCustomer(entity, cancellationToken);
			return NoContent();
		}

		/// <summary>
		/// Редактирование покупателя по id
		/// </summary>
		[HttpPut("{id:guid}")]
		[ProducesResponseType(typeof(ErrorValidationModel), StatusCodes.Status406NotAcceptable)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Edit(Guid id, AddCustomerApiModel request, CancellationToken cancellationToken)
		{
			var model = mapper.Map<CustomerModel>(request);
			model.Id = id;

			await customerService.EditCustomer(model, cancellationToken);
			return NoContent();
		}

		/// <summary>
		/// Удаляет покупателя по id
		/// </summary>
		[HttpDelete("{id:guid}")]
		[ProducesNotFound()]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
		{
			await customerService.DeleteCustomer(id, cancellationToken);
			return NoContent();
		}

	}
}
