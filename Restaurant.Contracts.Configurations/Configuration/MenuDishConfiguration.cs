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
	public class MenuDishConfiguration : IEntityTypeConfiguration<MenuDish>
	{
		public void Configure(EntityTypeBuilder<MenuDish> builder)
		{
			builder.ToTable("MenuDish");
			builder.HasKey(md => new { md.MenuId, md.DishId });

			builder.HasOne(md => md.Menu)
				.WithMany(m => m.MenuDishes)
				.HasForeignKey(md => md.MenuId);

			builder.HasOne(md => md.Dish)
				.WithMany(d => d.MenuDishes)
				.HasForeignKey(md => md.DishId);
		}
	}
}
