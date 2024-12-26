using AutoMapper;
using Restaurant.Contracts.Model;
using Restaurant.PackingListServices.Contracts.Model;

public class OrderServiceProfile : Profile
{
	public OrderServiceProfile()
	{
		// Маппинг для добавления нового заказа
		CreateMap<AddOrderModel, Order>()
			.ForMember(x => x.Id, opt => opt.MapFrom(_ => Guid.NewGuid())) // Генерация нового Id
			.ForMember(x => x.UpdatedAt, opt => opt.Ignore()) // Игнорирование автоматических полей
			.ForMember(x => x.Deleted, opt => opt.Ignore()) // Игнорирование автоматических полей
			.ForMember(x => x.Customer, opt => opt.Ignore()) // Навигационное свойство
			.ForMember(x => x.Delivery, opt => opt.Ignore()); // Навигационное свойство

		// Маппинг для связи "Заказ-Блюдо"
		CreateMap<OrderDishModel, OrderDish>()
			.ForMember(x => x.Id, opt => opt.Ignore()) // Игнорирование Id
			.ForMember(x => x.OrderId, opt => opt.Ignore()) // Игнорирование OrderId, оно будет установлено после сохранения заказа
			.ForMember(x => x.Order, opt => opt.Ignore()) // Навигационное свойство не нужно в модели, оно устанавливается автоматически
			.ForMember(x => x.DishId, opt => opt.MapFrom(d => d.DishId)) // Маппируем DishId
			.ForMember(x => x.Dish, opt => opt.Ignore()) // Навигационное свойство Dish не должно быть выставлено вручную
			.ForMember(x => x.Quantity, opt => opt.MapFrom(d => d.Quantity)); // Маппируем количество

		// Маппинг для Order → OrderModel
		CreateMap<Order, OrderModel>()
			.ForMember(dest => dest.Dishes, opt => opt.MapFrom(src => src.OrderDishes)); // Маппируем OrderDishes в Dishes

	}
}
