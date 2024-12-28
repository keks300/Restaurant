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
	/// <inheritdoc cref="IDeliveryService"/>
	public class DeliveryService : IDeliveryService
	{
		private readonly IMapper mapper;
		private readonly IReadRepository<Delivery> deliveryReadRepository;
		private readonly IWriteRepository<Delivery> deliveryWriteRepository;
		private readonly IUnitOfWork unitOfWork;

		//ctor
		public DeliveryService(
			IMapper mapper,
			IReadRepository<Delivery> deliveryReadRepository,
			IWriteRepository<Delivery> deliveryWriteRepository,
			IUnitOfWork unitOfWork)
        {
			this.mapper = mapper;
			this.deliveryReadRepository = deliveryReadRepository;
			this.deliveryWriteRepository = deliveryWriteRepository;
			this.unitOfWork = unitOfWork;
		}

		/// <inheritdoc/>
		public async Task<Guid> AddDelivery(AddDeliveryModel model, CancellationToken cancellationToken)
		{
			var entity = mapper.Map<Delivery>(model);
			deliveryWriteRepository.Add(entity);
			await unitOfWork.CommitAsync(cancellationToken);
			return entity.Id;
		}

		/// <inheritdoc/>
		public async Task DeleteDelivery(Guid id, CancellationToken cancellationToken)
		{
			var result = await deliveryReadRepository.GetById(id, cancellationToken);

			if (result == null)
			{
				throw new NotFoundModelException(id);
			}

			deliveryWriteRepository.HardDelete(result);
			await unitOfWork.CommitAsync(cancellationToken);
		}

		/// <inheritdoc/>
		public async Task EditDelivery(DeliveryModel model, CancellationToken cancellationToken)
		{
			var delivery = await deliveryReadRepository.GetById(model.Id, cancellationToken);

			if (delivery == null)
			{
				throw new NotFoundModelException(model.Id);
			}

			delivery.OrderId = model.OrderId;
			delivery.DeliveryAddress = model.DeliveryAddress;
			delivery.DeliveryDate = model.DeliveryDate;
			delivery.Status = model.Status;
			deliveryWriteRepository.Update(delivery);
			await unitOfWork.CommitAsync(cancellationToken);
		}

		/// <inheritdoc/>
		public async Task<IReadOnlyCollection<DeliveryModel>> GetAllDelivery(CancellationToken cancellationToken)
		{
			var delivery = await deliveryReadRepository.GetAll(cancellationToken);
			return mapper.Map<IReadOnlyCollection<DeliveryModel>>(delivery);
		}

		/// <inheritdoc/>
		public async Task<DeliveryModel> GetDeliveryById(Guid id, CancellationToken cancellationToken)
		{
			var delivery = await deliveryReadRepository.GetById(id, cancellationToken);

			return delivery == null
				? throw new NotFoundModelException(id)
				: mapper.Map<DeliveryModel>(delivery);
		}

	}
}
