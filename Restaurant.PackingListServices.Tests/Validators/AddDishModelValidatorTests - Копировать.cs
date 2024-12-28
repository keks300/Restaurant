using FluentValidation.TestHelper;
using Restaurant.PackingListServices.Contracts.Model;
using Restaurant.PackingListServices.Validators.Dish;
using WebApiTest.PackingListServices.Validators.OrderDish;
using Xunit;

namespace Restaurant.Services.Tests.Validators;

/// <summary>
///  Тесты для <see cref="OrderDishModelValidator" />
/// </summary>
public class AddOrderDishModelValidatorTest
{
    private readonly OrderDishModelValidator validator = new ();


    [Fact]
    public void ShouldHaveValidationErrorForEmpty()
    {
		// Arrange
		var model = new OrderDishModel
		{
            DishId = Guid.Empty,
        };

        //Act
        var result = validator.TestValidate(model);

        //Assert
        result.ShouldHaveValidationErrorFor(member => member.DishId);

    }

    [Fact]
    public void ShouldHaveValidationErrorForMinimumValue()
    {
		// Arrange
		var model = new OrderDishModel
		{
            Quantity = -5,
        };

        //Act
        var result = validator.TestValidate(model);

        //Assert
        result.ShouldHaveValidationErrorFor(member => member.Quantity);
    }

    [Fact]
    public void ShouldHaveNoErrors()
    {
		// Arrange
		var model = new OrderDishModel
		{
            DishId = Guid.NewGuid(),
            Quantity = 98
        };

        //Act
        var result = validator.TestValidate(model);

        //Assert
        result.ShouldNotHaveValidationErrorFor(member => member.DishId);
        result.ShouldNotHaveValidationErrorFor(member => member.Quantity);
    }
}
