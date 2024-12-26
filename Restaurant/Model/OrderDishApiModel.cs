using Restaurant.Contracts.Model;

namespace Restaurant.Model
{
	public class OrderDishApiModel
	{
		public Guid DishId { get; set; }
		public int Quantity { get; set; }
	}
}
