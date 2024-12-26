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
	/// <summary>
	/// 
	/// </summary>
	public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
	{
		public void Configure(EntityTypeBuilder<Delivery> builder)
		{
			builder.ToTable("Delivery");
			builder.HasKey(d => d.Id);

			builder.HasOne(d => d.Order)
				.WithOne(o => o.Delivery)
				.HasForeignKey<Delivery>(d => d.OrderId);
		}
	}
}
