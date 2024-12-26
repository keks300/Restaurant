﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Context.Contracts;
using Restaurant.Contracts.Model;



namespace WebApiTest.Api.Contracts.Configurations
{
	/// <summary>
	/// Конфигурация <see cref="Dish"/>
	/// </summary>
	public class DishConfiguration : IEntityTypeConfiguration<Dish>
	{
		public void Configure(EntityTypeBuilder<Dish> builder)
		{
			builder.ToTable("Dish");
			builder.HasKey(d => d.Id);

			builder.Property(d => d.Name)
				.IsRequired()
				.HasMaxLength(100);

			builder.HasIndex(d => d.Name)
				.IsUnique()
				.HasFilter("Deleted IS NULL");

			builder.HasMany(d => d.OrderDishes)
				.WithOne(od => od.Dish)
				.HasForeignKey(od => od.DishId);

			builder.HasMany(d => d.MenuDishes)
				.WithOne(md => md.Dish)
				.HasForeignKey(md => md.DishId);
		}
	}
}