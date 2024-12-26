using AutoMapper;
using Restaurant.Contracts.Model;
using Restaurant.PackingListServices.Contracts.Model;

namespace WebApiTest.PackingListServices.Infrastructure
{
	/// <summary>
	///  Профиль для <see cref"Customer"/>
	/// </summary>
	public class CustomerServiceProfile : Profile
	{
		public CustomerServiceProfile()
		{
			// Маппинг для добавления нового клиента
			CreateMap<AddCustomerModel, Customer>(MemberList.Destination)
				.ForMember(x => x.Id, _ => Guid.NewGuid()) // Генерация нового Id
				.ForMember(x => x.FullName, opt => opt.MapFrom(x => x.FullName))  // Маппинг имени
				.ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email)) // Маппинг Email
				.ForMember(x => x.Phone, opt => opt.MapFrom(x => x.Phone)) // Маппинг телефона
				.ForMember(x => x.CreatedAt, opt => opt.Ignore()) // Игнорирование CreatedAt
				.ForMember(x => x.UpdatedAt, opt => opt.Ignore()) // Игнорирование UpdatedAt
				.ForMember(x => x.Deleted, opt => opt.Ignore()); // Игнорирование Deleted

			// Маппинг для преобразования клиента в модель
			CreateMap<Customer, CustomerModel>(MemberList.Destination);
		}
	}

}
