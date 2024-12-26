namespace Restaurant.PackingListServices.Contracts.Model
{
	/// <summary>
	/// 
	/// </summary>
	public class AddMenuModel
	{
		/// <summary>
		/// 
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public List<Guid> DishIds { get; set; }  // Список Id блюд в меню

	}
}
