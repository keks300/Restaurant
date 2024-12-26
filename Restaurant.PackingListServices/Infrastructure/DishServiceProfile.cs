using AutoMapper;
using Restaurant.Contracts.Model;
using Restaurant.PackingListServices.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.PackingListServices.Infrastructure
{
	public class DishServiceProfile : Profile
	{
		public DishServiceProfile()
		{
			// Маппинг для добавления нового блюда
			CreateMap<AddDishModel, Dish>(MemberList.Destination)
				.ForMember(x => x.Id, _ => Guid.NewGuid()) // Генерация нового Id
				.ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))  // Маппинг имени
				.ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description)) // Маппинг описания
				.ForMember(x => x.CreatedAt, opt => opt.Ignore()) // Игнорирование CreatedAt
				.ForMember(x => x.UpdatedAt, opt => opt.Ignore()) // Игнорирование UpdatedAt
				.ForMember(x => x.Deleted, opt => opt.Ignore()); // Игнорирование Deleted

			// Маппинг для преобразования блюда в модель
			CreateMap<Dish, DishModel>(MemberList.Destination);
		}
	}
}
