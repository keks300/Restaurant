namespace Restaurant.PackingListServices.Contracts.Model
{
	public class AddDeliveryModel
	{
		public Guid OrderId { get; set; }
		public string DeliveryAddress { get; set; }
		public DateTime DeliveryDate { get; set; }
		public string Status { get; set; }
	}
}
