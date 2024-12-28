using FluentAssertions;
using Xunit;
using Restaurant.Repositories.Contracts;
using Restaurant.Contracts.Model;
using Restautant.Context.Tests;
using Restaurant.Repositories;

namespace DeliveryOffice.DataAccess.Repositories.Tests;

public class SupplierReaderRepositoryTests : BaseAppContextTest
{
    private readonly IReadRepository<Dish> repository;

    public SupplierReaderRepositoryTests()
    {
		repository = new ReadRepository<Dish>(Context);
	}

    [Fact]
    public async Task GetAllShouldReturnEmpty()
    {
        // Act
        var result = await repository.GetAll(token);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAllShouldReturnValue()
    {
        // Arrange
        var supplier1 = Ahatornn.TestGenerator.TestEntityProvider.Shared.Create<Dish>();
        var supplier2 = Ahatornn.TestGenerator.TestEntityProvider.Shared.Create<Dish>(s => s.Deleted = DateTime.UtcNow);
        var supplier3 = Ahatornn.TestGenerator.TestEntityProvider.Shared.Create<Dish>();
        await Context.AddRangeAsync(supplier1, supplier2, supplier3);
        await Context.SaveChangesAsync(token);

        // Act
        var result = await repository.GetAll(token);

        // Assert
        result.Should().NotBeEmpty()
            .And.HaveCount(2)
            .And.ContainSingle(s => s.Id == supplier1.Id)
            .And.ContainSingle(s => s.Id == supplier3.Id);
    }


}
