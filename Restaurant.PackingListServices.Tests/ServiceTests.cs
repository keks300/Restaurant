
using Ahatornn.TestGenerator;
using AutoMapper;
using FluentAssertions;
using Moq;
using Restaurant.Common.Abstractions;
using Restaurant.Context.Contracts;
using Restaurant.Context.Tests;
using Restaurant.Contracts.Model;
using Restaurant.PackingListServices.Contracts.Model;
using Restaurant.PackingListServices.Contracts.Service;
using Restaurant.PackingListServices.Infrastructure;
using Restaurant.PackingListServices.Service;
using Restaurant.Repositories;
using Restaurant.Repositories.Contracts;
using AppContext = Restaurant.Context.AppContext;

namespace DeliveryOffice.Services.Tests
{
    public class DishServiceTests 
	{
		private readonly IDishService dishService;
		private readonly Mock<IWriteRepository<Dish>> writeRepositoryMock;
		private readonly Mock<IReadRepository<Dish>> readRepositoryMock;
		private readonly Mock<IUnitOfWork> unitOfWorkMock;
		private readonly IMapper mapper;
		public DishServiceTests()
		{
			// Настройка AutoMapper
			var config = new MapperConfiguration(cfg => cfg.AddProfile<DishServiceProfile>());
			mapper = new Mapper(config);

			// Создание моков
			writeRepositoryMock = new Mock<IWriteRepository<Dish>>();
			readRepositoryMock = new Mock<IReadRepository<Dish>>();
			unitOfWorkMock = new Mock<IUnitOfWork>();

			// Создание тестируемого сервиса
			dishService = new DishService(
				mapper,
				readRepositoryMock.Object,
				writeRepositoryMock.Object,
				unitOfWorkMock.Object);
		}

		[Fact]
		public async Task AddDishShouldWork()
		{
			// Arrange
			var addDishModel = TestEntityProvider.Shared.Create<AddDishModel>();


			var generatedId = Guid.NewGuid();

			// Настраиваем мок репозитория
			writeRepositoryMock.Setup(x => x.Add(It.IsAny<Dish>()))
				.Callback<Dish>(dish =>
				{
					dish.Id = generatedId; // Присваиваем сгенерированный Id
				});

			// Настраиваем вызов CommitAsync
			unitOfWorkMock.Setup(x => x.CommitAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

			// Act
			var result = await dishService.AddDish(addDishModel, CancellationToken.None);

			// Assert
			result.Should().NotBe(Guid.Empty);
			writeRepositoryMock.Verify(x => x.Add(It.IsAny<Dish>()), Times.Once);
			unitOfWorkMock.Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
		}


		[Fact]
		public async Task GetAllDishesShouldWork()
		{
			// Arrange
			var addDishModel1 = TestEntityProvider.Shared.Create<Dish>();
			var addDishModel2 = TestEntityProvider.Shared.Create<Dish>();

			var dishes = new List<Dish>
			{
				addDishModel1,
				addDishModel2,
			};

			readRepositoryMock.Setup(x => x.GetAll(It.IsAny<CancellationToken>()))
				.ReturnsAsync(dishes);

			// Act
			var result = await dishService.GetAllDishes(CancellationToken.None);

			// Assert
			result.Should().NotBeNull();
			Assert.Equal(dishes.Count, result.Count);
			readRepositoryMock.Verify(x => x.GetAll(It.IsAny<CancellationToken>()), Times.Once);
		}

		[Fact]
		public async Task DeleteDishShouldWork()
		{
			// Arrange
			var dish = TestEntityProvider.Shared.Create<Dish>(); // Создаём тестовую сущность блюда

			// Настроим мок для поиска блюда по ID
			readRepositoryMock.Setup(x => x.GetById(dish.Id, It.IsAny<CancellationToken>()))
				.ReturnsAsync(dish); // Возвращаем найденное блюдо

			// Настроим мок для метода удаления
			writeRepositoryMock.Setup(x => x.Delete(It.IsAny<Dish>()));

			// Настроим мок для CommitAsync
			unitOfWorkMock.Setup(x => x.CommitAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

			// Act
			await dishService.DeleteDish(dish.Id, CancellationToken.None);

			// Assert
			writeRepositoryMock.Verify(x => x.Delete(It.Is<Dish>(d => d.Id == dish.Id)), Times.Once); // Проверяем, что метод Delete был вызван один раз
			unitOfWorkMock.Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once); // Проверяем, что CommitAsync был вызван один раз
		}

		[Fact]
		public async Task EditDishShouldWork()
		{
			// Arrange
			var dishId = Guid.NewGuid();
			var model = TestEntityProvider.Shared.Create<DishModel>();
			var existingDish = TestEntityProvider.Shared.Create<Dish>();
			model.Id = dishId;
			existingDish.Id = dishId;

			// Настроим мок для поиска блюда по ID
			readRepositoryMock.Setup(x => x.GetById(dishId, It.IsAny<CancellationToken>()))
				.ReturnsAsync(existingDish); // Возвращаем существующее блюдо

			// Настроим мок для метода Update
			writeRepositoryMock.Setup(x => x.Update(It.IsAny<Dish>()));

			// Настроим мок для CommitAsync
			unitOfWorkMock.Setup(x => x.CommitAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

			// Act
			await dishService.EditDish(model, CancellationToken.None);

			// Assert
			writeRepositoryMock.Verify(x => x.Update(It.Is<Dish>(d =>
				d.Id == dishId &&
				d.Name == model.Name &&
				d.Description == model.Description &&
				d.Price == model.Price)), Times.Once); // Проверяем, что Update был вызван с обновлёнными данными
			unitOfWorkMock.Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once); // Проверяем, что CommitAsync был вызван один раз
		}

		[Fact]
		public async Task GetDishByIdShouldWork()
		{
			// Arrange
			var dishId = Guid.NewGuid();
			var existingDish = new Dish
			{
				Id = dishId,
				Name = "Dish Name",
				Description = "Dish Description",
				Price = 12.99m
			};

			var expectedDishModel = new DishModel
			{
				Id = dishId,
				Name = "Dish Name",
				Description = "Dish Description",
				Price = 12.99m
			};

			existingDish.Id = dishId;
			expectedDishModel.Id = dishId;


			// Настроим мок для поиска блюда по ID
			readRepositoryMock.Setup(x => x.GetById(dishId, It.IsAny<CancellationToken>()))
				.ReturnsAsync(existingDish); // Возвращаем существующее блюдо

			// Настроим AutoMapper для маппинга

			// Act
			var result = await dishService.GetDishById(dishId, CancellationToken.None);

			// Assert
			result.Should().NotBeNull();
			result.Should().BeEquivalentTo(expectedDishModel); // Проверяем, что результат эквивалентен ожидаемой модели
			readRepositoryMock.Verify(x => x.GetById(dishId, It.IsAny<CancellationToken>()), Times.Once); // Проверяем, что GetById был вызван один раз
		}


	}
}
