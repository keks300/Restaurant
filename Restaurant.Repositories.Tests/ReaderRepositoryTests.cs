using FluentAssertions;
using Xunit;
using Restaurant.Repositories.Contracts;
using Restaurant.Contracts.Model;
using Restautant.Context.Tests;
using Restaurant.Repositories;
using Ahatornn.TestGenerator;

namespace Restaurant.DataAccess.Repositories.Tests
{
    public class ReaderRepositoryTests : BaseAppContextTest
    {

		/// <summary>
		/// Возвращает пустой <see cref="Dish"/>
		/// </summary>
		[Fact]
		public async Task GetAllShouldReturnEmptyForDish()
		{
			var repository = new ReadRepository<Dish>(Context);
			await TestGetAllShouldReturnEmpty(repository);
		}

		/// <summary>
		/// Возвращает 2 <see cref="Dish"/>
		/// </summary>
		[Fact]
		public async Task GetAllShouldReturnValueForDish()
		{
			// Arrange
			var dish1 = TestEntityProvider.Shared.Create<Dish>();
			var dish2 = TestEntityProvider.Shared.Create<Dish>(s => s.Deleted = DateTime.UtcNow);
			var dish3 = TestEntityProvider.Shared.Create<Dish>();
			await Context.AddRangeAsync(dish1, dish2, dish3);
			await Context.SaveChangesAsync(token);

			// Act

			var repository = new ReadRepository<Dish>(Context);
			var result = await repository.GetAll(token);

			// Assert
			result.Should().NotBeEmpty()
				.And.HaveCount(2)
				.And.ContainSingle(s => s.Id == dish1.Id)
				.And.ContainSingle(s => s.Id == dish3.Id);
		}

		/// <summary>
		/// Возвращает пустой <see cref="Delivery"/>
		/// </summary>
		[Fact]
		public async Task GetAllShouldReturnEmptyForDelivery()
		{
			var repository = new ReadRepository<Delivery>(Context);
			await TestGetAllShouldReturnEmpty(repository);
		}

		/// <summary>
		/// Возвращает 2 <see cref="Delivery"/>
		/// </summary>
		[Fact]
		public async Task GetAllShouldReturnValueForDelivery()
		{
			// Arrange
			var delivery1 = TestEntityProvider.Shared.Create<Delivery>();
			var delivery2 = TestEntityProvider.Shared.Create<Delivery>(s => s.Deleted = DateTime.UtcNow);
			var delivery3 = TestEntityProvider.Shared.Create<Delivery>();
			await Context.AddRangeAsync(delivery1, delivery2, delivery3);
			await Context.SaveChangesAsync(token);

			// Act

			var repository = new ReadRepository<Delivery>(Context);
			var result = await repository.GetAll(token);

			// Assert
			result.Should().NotBeEmpty()
				.And.HaveCount(2)
				.And.ContainSingle(s => s.Id == delivery1.Id)
				.And.ContainSingle(s => s.Id == delivery3.Id);
		}

		/// <summary>
		/// Возвращает пустой <see cref="Order"/>
		/// </summary>
		[Fact]
		public async Task GetAllShouldReturnEmptyForOrder()
		{
			var repository = new ReadRepository<Order>(Context);
			await TestGetAllShouldReturnEmpty(repository);
		}

		/// <summary>
		/// Возвращает 2 <see cref="Order"/>
		/// </summary>
		[Fact]
		public async Task GetAllShouldReturnValueForOrder()
		{
			// Arrange
			var order1 = TestEntityProvider.Shared.Create<Order>();
			var order2 = TestEntityProvider.Shared.Create<Order>(s => s.Deleted = DateTime.UtcNow);
			var order3 = TestEntityProvider.Shared.Create<Order>();
			await Context.AddRangeAsync(order1, order2, order3);
			await Context.SaveChangesAsync(token);

			// Act

			var repository = new ReadRepository<Order>(Context);
			var result = await repository.GetAll(token);

			// Assert
			result.Should().NotBeEmpty()
				.And.HaveCount(2)
				.And.ContainSingle(s => s.Id == order1.Id)
				.And.ContainSingle(s => s.Id == order3.Id);
		}

		/// <summary>
		/// Возвращает пустой <see cref="OrderDish"/>
		/// </summary>
		[Fact]
		public async Task GetAllShouldReturnEmptyForOrderInDish()
		{
			var repository = new ReadRepository<OrderDish>(Context);
			await TestGetAllShouldReturnEmpty(repository);
		}

		/// <summary>
		/// Возвращает 2 <see cref="OrderDish"/>
		/// </summary>
		[Fact]
		public async Task GetAllShouldReturnValueForOrderInDish()
		{
			// Arrange
			var orderDish1 = TestEntityProvider.Shared.Create<OrderDish>();
			var orderDish2 = TestEntityProvider.Shared.Create<OrderDish>(s => s.Deleted = DateTime.UtcNow);
			var orderDish3 = TestEntityProvider.Shared.Create<OrderDish>();
			await Context.AddRangeAsync(orderDish1, orderDish2, orderDish3);
			await Context.SaveChangesAsync(token);

			// Act

			var repository = new ReadRepository<OrderDish>(Context);
			var result = await repository.GetAll(token);

			// Assert
			result.Should().NotBeEmpty()
				.And.HaveCount(2)
				.And.ContainSingle(s => s.Id == orderDish1.Id)
				.And.ContainSingle(s => s.Id == orderDish3.Id);
		}

		private async Task TestGetAllShouldReturnEmpty<T>(IReadRepository<T> repository) where T : class, new()
		{
			// Act
			var result = await repository.GetAll(token);

			// Assert
			result.Should().BeEmpty();
		}

    }
}
