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
	public class MenuConfiguration : IEntityTypeConfiguration<Menu>
	{
		public void Configure(EntityTypeBuilder<Menu> builder)
		{
			builder.ToTable("Menu");
			builder.HasKey(m => m.Id);

			builder.Property(m => m.Name)
				.IsRequired()
				.HasMaxLength(100);

			builder.HasMany(m => m.MenuDishes)
				.WithOne(md => md.Menu)
				.HasForeignKey(md => md.MenuId);
		}
	}

}
