namespace Restaurant.Model
{
	/// <summary>
	/// 
	/// </summary>
	public class AddMenuApiModel
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
