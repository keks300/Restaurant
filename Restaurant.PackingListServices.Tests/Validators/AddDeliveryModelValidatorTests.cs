using Restaurant.PackingListServices.Contracts.Model;
using Restaurant.PackingListServices.Validators.Delivery;
using FluentValidation.TestHelper;
using Restaurant.Contracts;

namespace Restaurant.PackingListServices.Tests.Validators
{
	/// <summary>
	///  Тесты для <see cref="AddDeliveryModelValidator" />
	/// </summary>
	public class AddDeliveryModelValidatorTests
	{
		private readonly AddDeliveryModelValidator validator = new();

		[Fact]
		public void ShouldHaveValidationErrorForMaxValue()
		{
			// Arrange
			var model = new AddDeliveryModel
			{
				DeliveryAddress = new string('a', 300),
				DeliveryDate = DateTime.Now.AddDays(-1),
				Status = (Status)5,
			};

			//Act
			var result = validator.TestValidate(model);

			//Assert
			result.ShouldHaveValidationErrorFor(member => member.DeliveryAddress);
			result.ShouldHaveValidationErrorFor(member => member.DeliveryDate);
			result.ShouldHaveValidationErrorFor(member => member.Status);
		}

		[Fact]
		public void ShouldHaveValidationErrorForNull()
		{
			// Arrange
			var model = new AddDeliveryModel
			{
				DeliveryAddress = null,
			};

			//Act
			var result = validator.TestValidate(model);

			//Assert
			result.ShouldHaveValidationErrorFor(member => member.DeliveryAddress);
		}

		[Fact]
		public void ShouldHaveValidationErrorForEmpty()
		{
			// Arrange
			var model = new AddDeliveryModel
			{
				OrderId = Guid.Empty,
				DeliveryAddress = string.Empty,
			};

			//Act
			var result = validator.TestValidate(model);

			//Assert
			result.ShouldHaveValidationErrorFor(member => member.OrderId);
			result.ShouldHaveValidationErrorFor(member => member.DeliveryAddress);
		}

		[Fact]
		public void ShouldHaveNoErrors()
		{
			// Arrange
			var model = new AddDeliveryModel
			{
				OrderId = Guid.NewGuid(),
				DeliveryAddress = "проспект Авиаконструкторов, 28, Санкт-Петербург",
				DeliveryDate = DateTime.Now,
				Status = Status.Pending
			};

			//Act
			var result = validator.TestValidate(model);

			//Assert
			result.ShouldNotHaveValidationErrorFor(member => member.OrderId);
			result.ShouldNotHaveValidationErrorFor(member => member.DeliveryAddress);
			result.ShouldNotHaveValidationErrorFor(member => member.DeliveryDate);
			result.ShouldNotHaveValidationErrorFor(member => member.Status);
		}
	}
}
