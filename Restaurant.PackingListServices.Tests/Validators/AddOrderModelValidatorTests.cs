using FluentValidation.TestHelper;
using Restaurant.Contracts;
using Restaurant.PackingListServices.Contracts.Model;
using Restaurant.PackingListServices.Validators.Order;

namespace Restaurant.PackingListServices.Tests.Validators
{
	/// <summary>
	///  Тесты для <see cref="AddOrderModelValidator" />
	/// </summary>
	public class AddOrderModelValidatorTests
	{
		private readonly AddOrderModelValidator validator = new();

		[Fact]
		public void ShouldHaveValidationErrorForNull()
		{
			// Arrange
			var model = new AddOrderModel
			{
				Dishes = null,
			};

			//Act
			var result = validator.TestValidate(model);

			//Assert
			result.ShouldHaveValidationErrorFor(member => member.Dishes);
		}

		[Fact]
		public void ShouldHaveValidationErrorForEmpty()
		{
			// Arrange
			var model = new AddOrderModel
			{
				CustomerId = Guid.Empty,
			};

			//Act
			var result = validator.TestValidate(model);

			//Assert
			result.ShouldHaveValidationErrorFor(member => member.CustomerId);
		}

		[Fact]
		public void ShouldHaveNoErrors()
		{
			// Arrange
			var model = new AddOrderModel
			{
				CustomerId = Guid.NewGuid(),
				Dishes = new List<OrderDishModel> { new(), new()},
			};

			//Act
			var result = validator.TestValidate(model);

			//Assert
			result.ShouldNotHaveValidationErrorFor(member => member.CustomerId);
			result.ShouldNotHaveValidationErrorFor(member => member.Dishes);
		}
	}
}
