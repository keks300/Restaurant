using FluentValidation.TestHelper;
using Restaurant.PackingListServices.Contracts.Model;
using Restaurant.PackingListServices.Validators.Dish;
using Xunit;

namespace Restaurant.Services.Tests.Validators;

/// <summary>
///  Тесты для <see cref="AddDishModelValidator" />
/// </summary>
public class AddDishModelValidatorTest
{
    private readonly AddDishModelValidator validator = new ();

    [Fact]
    public void ShouldHaveValidationErrorForMaximumLength()
    {
		// Arrange
		var model = new AddDishModel
		{
            Name = new string('a', 300),
            Description = new string('a', 300),
        };

        //Act
        var result = validator.TestValidate(model);

        //Assert
        result.ShouldHaveValidationErrorFor(member => member.Name);
        result.ShouldHaveValidationErrorFor(member => member.Description);
    }

    [Fact]
    public void ShouldHaveValidationErrorForNull()
    {
		// Arrange
		var model = new AddDishModel
		{
            Name = null,
            Description = null,
        };

        //Act
        var result = validator.TestValidate(model);

        //Assert
        result.ShouldHaveValidationErrorFor(member => member.Name);
        result.ShouldHaveValidationErrorFor(member => member.Description);
    }

    [Fact]
    public void ShouldHaveValidationErrorForEmpty()
    {
		// Arrange
		var model = new AddDishModel
		{
            Name = string.Empty,
            Description = string.Empty,
        };

        //Act
        var result = validator.TestValidate(model);

        //Assert
        result.ShouldHaveValidationErrorFor(member => member.Name);
        result.ShouldHaveValidationErrorFor(member => member.Description);
    }

    [Fact]
    public void ShouldHaveValidationErrorForMinimumValue()
    {
		// Arrange
		var model = new AddDishModel
        {
            Price = -50,
        };

        //Act
        var result = validator.TestValidate(model);

        //Assert
        result.ShouldHaveValidationErrorFor(member => member.Price);
    }

    [Fact]
    public void ShouldHaveNoErrors()
    {
		// Arrange
		var model = new AddDishModel
		{
            Name = "Ежевика в шоколаде",
            Description = "Отлично подойдет для любителей сладкого. Сочетание нежного кофе с сиропами ежевика и шоколадное печенье.",
            Price = 228,
        };

        //Act
        var result = validator.TestValidate(model);

        //Assert
        result.ShouldNotHaveValidationErrorFor(member => member.Name);
        result.ShouldNotHaveValidationErrorFor(member => member.Description);
        result.ShouldNotHaveValidationErrorFor(member => member.Price);
    }
}
