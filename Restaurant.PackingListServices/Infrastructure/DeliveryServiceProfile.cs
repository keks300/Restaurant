using AutoMapper;
using Restaurant.Contracts.Model;
using Restaurant.PackingListServices.Contracts.Model;

namespace WebApiTest.PackingListServices.Infrastructure
{
	public class DeliveryServiceProfile : Profile
	{
		public DeliveryServiceProfile()
		{
			// Маппинг для добавления новой доставки
			CreateMap<AddDeliveryModel, Delivery>(MemberList.Destination)
				.ForMember(x => x.Id, _ => Guid.NewGuid()) // Генерация нового Id
				.ForMember(x => x.DeliveryDate, opt => opt.MapFrom(x => DateTime.Now)) // Маппинг даты доставки
				.ForMember(x => x.Status, opt => opt.MapFrom(x => x.Status)) // Маппинг статуса
				.ForMember(x => x.CreatedAt, opt => opt.Ignore()) // Игнорирование CreatedAt
				.ForMember(x => x.UpdatedAt, opt => opt.Ignore()) // Игнорирование UpdatedAt
				.ForMember(x => x.Deleted, opt => opt.Ignore()); // Игнорирование Deleted

			// Маппинг для преобразования доставки в модель
			CreateMap<Delivery, DeliveryModel>(MemberList.Destination);
		}
	}
}
