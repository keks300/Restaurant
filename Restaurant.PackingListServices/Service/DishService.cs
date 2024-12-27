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
	/// <inheritdoc cref="IDishService"/>
	public class DishService : IDishService
	{
        private readonly IMapper mapper;
		private readonly IReadRepository<Dish> dishReadRepository;
		private readonly IWriteRepository<Dish> dishWriteRepository;
		private readonly IUnitOfWork unitOfWork;

		/// <summary>
		/// ctor
		/// </summary>
        public DishService(
			IMapper mapper, 
			IReadRepository<Dish> dishReadRepository,
			IWriteRepository<Dish> dishWriteRepository,
			IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
			this.dishReadRepository = dishReadRepository;
			this.dishWriteRepository = dishWriteRepository;
			this.unitOfWork = unitOfWork;
        }

		/// <inheritdoc/>
        public async Task<Guid> AddDish(AddDishModel model, CancellationToken cancellationToken)
		{
			var entity = mapper.Map<Dish>(model);
			dishWriteRepository.Add(entity);
			await unitOfWork.CommitAsync(cancellationToken);
			return entity.Id;
		}

		/// <inheritdoc/>
		public async Task DeleteDish(Guid id, CancellationToken cancellationToken)
		{
			var result = await dishReadRepository.GetById(id, cancellationToken);

			if (result == null)
			{
				throw new NotFoundModelException(id);
			}

			dishWriteRepository.Delete(result);
			await unitOfWork.CommitAsync(cancellationToken);
		}

		/// <inheritdoc/>
		public async Task EditDish(DishModel model, CancellationToken cancellationToken)
		{
			var dish = await dishReadRepository.GetById(model.Id, cancellationToken);

			if (dish == null)
			{
				throw new NotFoundModelException(model.Id);
			}

			dish.Name = model.Name;
			dish.Description = model.Description;
			dish.Price = model.Price;
			dishWriteRepository.Update(dish);
			await unitOfWork.CommitAsync(cancellationToken);
		}

		/// <inheritdoc/>
		public async Task<IReadOnlyCollection<DishModel>> GetAllDishes(CancellationToken cancellationToken)
		{
			var dishes = await dishReadRepository.GetAll(cancellationToken);
			return mapper.Map<IReadOnlyCollection<DishModel>>(dishes);
		}

		/// <inheritdoc/>
		public async Task<DishModel> GetDishById(Guid id, CancellationToken cancellationToken)
		{
			var dish = await dishReadRepository.GetById(id, cancellationToken);

			return dish == null
				? throw new NotFoundModelException(id)
				: mapper.Map<DishModel>(dish);
		}
	}
}
