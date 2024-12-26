using Microsoft.EntityFrameworkCore;
using Restaurant.Context.Contracts;
using Restaurant.Contracts.Model;
using Restaurant.Repositories.Contracts;
using Restaurant.Context.Contracts.Specs;


namespace Restaurant.Repositories.OrderRepository.OrderDishRepository
{
	public class OrderDishReadRepository 
	{
		private readonly IReader reader;

		/// <summary>
		/// ctor
		/// </summary>
		public OrderDishReadRepository(IReader reader)
        {
			this.reader = reader;
		}

        public async Task<IReadOnlyCollection<OrderDish>> GetAll(CancellationToken cancellationToken)
		=> await reader.Read<OrderDish>().ToListAsync(cancellationToken);

		//public Task<OrderDish?> GetById(Guid id, CancellationToken cancellationToken)
		//	=> reader.Read<OrderDish>()
		//	.NotDeleted()
		//	.GetById(id)
		//	.FirstOrDefaultAsync(cancellationToken);
	}
}
