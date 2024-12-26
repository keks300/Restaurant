using AutoMapper;
using Restaurant.Contracts.Model;
using Restaurant.PackingListServices.Contracts.Model;

namespace WebApiTest.PackingListServices.Infrastructure
{
	public class MenuServiceProfile : Profile
	{
		public MenuServiceProfile()
		{
			// Маппинг для добавления нового меню
			CreateMap<AddMenuModel, Menu>(MemberList.Destination)
				.ForMember(x => x.Id, _ => Guid.NewGuid()) // Генерация нового Id
				.ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))  // Маппинг имени
				.ForMember(x => x.CreatedAt, opt => opt.Ignore()) // Игнорирование CreatedAt
				.ForMember(x => x.UpdatedAt, opt => opt.Ignore()) // Игнорирование UpdatedAt
				.ForMember(x => x.Deleted, opt => opt.Ignore()); // Игнорирование Deleted

			// Маппинг для преобразования меню в модель
			CreateMap<Menu, MenuModel>(MemberList.Destination);
		}
	}
}
