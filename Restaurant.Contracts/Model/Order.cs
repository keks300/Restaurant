using Restaurant.Context.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Restaurant.Contracts.Model
{
	public class Order : IAuditableEntity, ISoftDeleted, IEntityWithId
	{
		public Guid Id { get; set; }
		public Guid CustomerId { get; set; }
		public decimal TotalAmount { get; set; }

		public DateTimeOffset CreatedAt { get; set; }

		public DateTimeOffset UpdatedAt { get; set; }

		public DateTimeOffset? Deleted { get; set; }

		public Customer Customer { get; set; }

		public ICollection<OrderDish> OrderDishes { get; set; }

		public Delivery Delivery { get; set; }
	}
}
