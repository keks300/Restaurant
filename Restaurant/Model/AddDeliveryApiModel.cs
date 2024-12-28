using Restaurant.Contracts;

namespace Restaurant.Model
{
	public class AddDeliveryApiModel
	{
		public Guid OrderId { get; set; }
		public string DeliveryAddress { get; set; }
		public DateTime DeliveryDate { get; set; }
		public Status Status { get; set; }
	}
}
