using Restaurant.Contracts;
using System.Text.Json.Serialization;

namespace Restaurant.PackingListServices.Contracts.Model
{
	public class AddDeliveryModel
	{
		public Guid OrderId { get; set; }
		public string DeliveryAddress { get; set; }
		public DateTime DeliveryDate { get; set; }
		public Status Status { get; set; }
	}
}
