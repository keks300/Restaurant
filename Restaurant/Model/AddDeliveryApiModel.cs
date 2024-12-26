namespace Restaurant.Model
{
	public class AddDeliveryApiModel
	{
		public Guid OrderId { get; set; }
		public string DeliveryAddress { get; set; }
		public DateTime DeliveryDate { get; set; }
		public string Status { get; set; }
	}
}
