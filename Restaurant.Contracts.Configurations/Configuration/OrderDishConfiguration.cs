using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Contracts.Model;

namespace Restaurant.Contracts.Configurations.Configuration
{
	public class OrderDishConfiguration : IEntityTypeConfiguration<OrderDish>
	{
		public void Configure(EntityTypeBuilder<OrderDish> builder)
		{
			builder.ToTable("OrderDish");
			builder.HasKey(od => od.Id);

			builder.HasOne(od => od.Order)
				.WithMany(o => o.OrderDishes)
				.HasForeignKey(od => od.OrderId);

			builder.HasOne(od => od.Dish)
				.WithMany(d => d.OrderDishes)
				.HasForeignKey(od => od.DishId);
		}
	}
}
