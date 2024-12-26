using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Restaurant.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Contracts.Configurations.Configuration
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("Order");
			builder.HasKey(o => o.Id);

			builder.HasOne(o => o.Customer)
				.WithMany(c => c.Orders)
				.HasForeignKey(o => o.CustomerId);

			builder.HasMany(o => o.OrderDishes)
				.WithOne(od => od.Order)
				.HasForeignKey(od => od.OrderId);

			builder.HasOne(o => o.Delivery)
				.WithOne(d => d.Order)
				.HasForeignKey<Delivery>(d => d.OrderId);
		}
	}
}
