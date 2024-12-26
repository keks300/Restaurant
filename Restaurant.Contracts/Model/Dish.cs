using Restaurant.Context.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Contracts.Model
{
	/// <summary>
	/// Блюдо
	/// </summary>
	public class Dish : IAuditableEntity, ISoftDeleted, IEntityWithId
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
		public DateTimeOffset UpdatedAt { get; set; }
		public DateTimeOffset? Deleted { get; set; }

		// Навигационные свойства
		public ICollection<OrderDish> OrderDishes { get; set; }
		public ICollection<MenuDish> MenuDishes { get; set; }
	}
}
