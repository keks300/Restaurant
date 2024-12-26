using AutoMapper;
using Restaurant.PackingListServices.Contracts.Model;
using Restaurant.Model;

namespace WebApplication2.Infrastructure
{
	public class ApiProfile : Profile
	{
		public ApiProfile()
		{
			// Маппинг для Dish
			CreateMap<DishModel, DishApiModel>(MemberList.Destination);
			CreateMap<AddDishApiModel, AddDishModel>(MemberList.Destination);
			CreateMap<AddDishApiModel, DishModel>(MemberList.Destination)
				.ForMember(x => x.Id, opt => opt.Ignore());

			//Маппинг для Menu
				CreateMap<MenuModel, MenuApiModel>(MemberList.Destination);
			CreateMap<AddMenuApiModel, AddMenuModel>(MemberList.Destination);
			CreateMap<AddMenuApiModel, MenuModel>(MemberList.Destination)
				.ForMember(x => x.Id, opt => opt.Ignore());

			// Маппинг для Customer
			CreateMap<CustomerModel, CustomerApiModel>(MemberList.Destination);
			CreateMap<AddCustomerApiModel, AddCustomerModel>(MemberList.Destination);
			CreateMap<AddCustomerApiModel, CustomerModel>(MemberList.Destination)
				.ForMember(x => x.Id, opt => opt.Ignore());

			// Маппинг для Order
			CreateMap<OrderModel, OrderApiModel>(MemberList.Destination);
			CreateMap<AddOrderApiModel, AddOrderModel>(MemberList.Destination);
			CreateMap<AddOrderApiModel, OrderModel>(MemberList.Destination)
				.ForMember(x => x.Id, opt => opt.Ignore());

			// Маппинг для Delivery
			CreateMap<DeliveryModel, DeliveryApiModel>(MemberList.Destination);
			CreateMap<AddOrderApiModel, AddOrderModel>(MemberList.Destination);
			CreateMap<AddDeliveryApiModel, DeliveryModel>(MemberList.Destination)
				.ForMember(x => x.Id, opt => opt.Ignore());

			// Маппинг для OrderDish
			CreateMap<OrderDishApiModel, OrderDishModel>()
				.ForMember(x => x.DishId, opt => opt.MapFrom(d => d.DishId)) // Маппируем DishId
				.ForMember(x => x.Quantity, opt => opt.MapFrom(d => d.Quantity)); // Маппируем количество

			CreateMap<OrderDishModel, OrderDishApiModel>(MemberList.Destination);

			// Маппинг для добавления нового заказа
			CreateMap<AddOrderApiModel, AddOrderModel>()
				.ForMember(x => x.CustomerId, opt => opt.MapFrom(m => m.CustomerId)) // Маппируем CustomerId
				.ForMember(x => x.Dishes, opt => opt.MapFrom(m => m.Dishes)) // Маппируем список блюд
				.ReverseMap(); // Для двустороннего маппингауем Id, если он не должен быть установлен
		}
	}
}
