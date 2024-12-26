namespace Restaurant.Model
{
	/// <summary>
	/// 
	/// </summary>
	public class AddOrderApiModel
	{
		/// <summary>
		/// 
		/// </summary>
		public Guid CustomerId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public List<OrderDishApiModel> Dishes { get; set; }
	}
}

