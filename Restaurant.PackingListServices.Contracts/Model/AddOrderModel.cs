namespace Restaurant.PackingListServices.Contracts.Model
{
	/// <summary>
	/// 
	/// </summary>
	public class AddOrderModel
	{
		/// <summary>
		/// 
		/// </summary>
		public Guid CustomerId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public List<OrderDishModel> Dishes { get; set; }
	}
}

