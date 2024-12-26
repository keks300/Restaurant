using Restaurant.Common.Abstractions;
using Restaurant.Context.Contracts;
using Restaurant.Contracts.Model;
using Restaurant.Repositories.Contracts;

namespace Restaurant.Repositories.OrderRepository.OrderDishRepository
{
	public class OrderDishWriteRepository : BaseWriteRepository<OrderDish>, IWriteRepository<OrderDish>
	{
		public OrderDishWriteRepository(IWriter writer,
			IDateTimeProvider dateTimeProvider)
			: base(writer, dateTimeProvider)
		{
			{

			}
		}
	}
}
