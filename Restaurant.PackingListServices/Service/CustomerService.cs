using AutoMapper;
using Restaurant.Context.Contracts;
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
	/// <inheritdoc cref="ICustomerService"/>
	public class CustomerService : ICustomerService
	{
		private readonly IMapper mapper;
		private readonly IReadRepository<Customer> customerReadRepository;
		private readonly IWriteRepository<Customer> customerWriteRepository;
		private readonly IUnitOfWork unitOfWork;

		/// <summary>
		/// ctor
		/// </summary>
        public CustomerService(IMapper mapper, IReadRepository<Customer> customerReadRepository, IWriteRepository<Customer> customerWriteRepository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
			this.customerReadRepository = customerReadRepository;
			this.customerWriteRepository = customerWriteRepository;
			this.unitOfWork = unitOfWork;
        }

		/// <inheritdoc/>
        public async Task<Guid> AddCustomer(AddCustomerModel model, CancellationToken cancellationToken)
		{
			var entity = mapper.Map<Customer>(model);
			customerWriteRepository.Add(entity);
			await unitOfWork.CommitAsync(cancellationToken);
			return entity.Id;
		}

		/// <inheritdoc/>
		public async Task DeleteCustomer(Guid id, CancellationToken cancellationToken)
		{
			var result = await customerReadRepository.GetById(id, cancellationToken);

			if (result == null)
			{
				throw new NotFoundModelException(id);
			}

			customerWriteRepository.Delete(result);
			await unitOfWork.CommitAsync(cancellationToken);
		}

		/// <inheritdoc/>
		public async Task EditCustomer(CustomerModel model, CancellationToken cancellationToken)
		{
			var dish = await customerReadRepository.GetById(model.Id, cancellationToken);

			if (dish == null)
			{
				throw new NotFoundModelException(model.Id);
			}

			dish.FullName = model.FullName;
			dish.Email = model.Email;
			dish.Phone = model.Phone;
			customerWriteRepository.Update(dish);
			await unitOfWork.CommitAsync(cancellationToken);
		}

		/// <inheritdoc/>
		public async Task<IReadOnlyCollection<CustomerModel>> GetAllCustomers(CancellationToken cancellationToken)
		{
			var dishes = await customerReadRepository.GetAll(cancellationToken);
			return mapper.Map<IReadOnlyCollection<CustomerModel>>(dishes);
		}

		/// <inheritdoc/>
		public async Task<CustomerModel> GetCustomerById(Guid id, CancellationToken cancellationToken)
		{
			var dish = await customerReadRepository.GetById(id, cancellationToken);

			return dish == null
				? throw new NotFoundModelException(id)
				: mapper.Map<CustomerModel>(dish);
		}
	}
}
