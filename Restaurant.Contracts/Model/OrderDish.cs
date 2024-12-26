using Restaurant.Context.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Restaurant.Contracts.Model
{
	public class OrderDish: IAuditableEntity, ISoftDeleted, IEntityWithId
	{
		public Guid Id { get; set; }
		public Guid OrderId { get; set; }
		public Guid DishId { get; set; }
		public int Quantity { get; set; }

		// Навигационные свойства
		[JsonIgnore]
		public Order Order { get; set; }

		[JsonIgnore]
		public Dish Dish { get; set; }
		public DateTimeOffset? Deleted { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
		public DateTimeOffset UpdatedAt { get; set; }
	}
}

