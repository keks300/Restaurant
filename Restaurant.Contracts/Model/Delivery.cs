using Restaurant.Context.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Restaurant.Contracts.Model
{
	public class Delivery : IAuditableEntity, ISoftDeleted, IEntityWithId
	{
		public Guid Id { get; set; }
		public Guid OrderId { get; set; }
		public string DeliveryAddress { get; set; }
		public DateTime DeliveryDate { get; set; }

		[JsonConverter(typeof(JsonStringEnumConverter))]
		public Status Status { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
		public DateTimeOffset UpdatedAt { get; set; }
		public DateTimeOffset? Deleted { get; set; }

		// Навигационные свойства
		public Order Order { get; set; }
	}
}
