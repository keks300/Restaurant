using Restaurant.Context.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Contracts.Model
{
	/// <summary>
	/// Меню
	/// </summary>
	public class Menu : IAuditableEntity, ISoftDeleted, IEntityWithId
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
		public DateTimeOffset UpdatedAt { get; set; }
		public DateTimeOffset? Deleted { get; set; }

		// Навигационные свойства
		public ICollection<MenuDish> MenuDishes { get; set; }
	}
}
