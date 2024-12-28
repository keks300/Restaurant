using Microsoft.EntityFrameworkCore;
using Restaurant;
using Restaurant.Common;
using Restaurant.Common.Abstractions;
using Restaurant.Context.Contracts;
using Restaurant.Infrastructure;
using Restaurant.PackingListServices.Contracts.Service;
using Restaurant.PackingListServices.Infrastructure;
using Restaurant.PackingListServices.Service;
using Restaurant.PackingListServices.ValidationService;
using WebApiTest.PackingListServices;
using WebApiTest.PackingListServices.Infrastructure;
using Restaurant.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(x =>
{
	x.Filters.Add<CustomExceptionFilter>();
});

// Add services to the container.
builder.Services.AddDbContext<Restaurant.Context.AppContext>(opt =>
	opt.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString")));

builder.Services.AddScoped<IReader>(c => c.GetRequiredService<Restaurant.Context.AppContext>());
builder.Services.AddScoped<IUnitOfWork>(c => c.GetRequiredService<Restaurant.Context.AppContext>());
builder.Services.AddScoped<IWriter>(c => c.GetRequiredService<Restaurant.Context.AppContext>());

// Регистрация репозиториев для всех сущностей
builder.Services.AddRepositoryServices();

// Регистрация всех профилей AutoMapper
builder.Services.AddAutoMapper(
	typeof(ApiProfile),
	typeof(DishServiceProfile),
	typeof(OrderServiceProfile),
	typeof(CustomerServiceProfile),
	typeof(DeliveryServiceProfile)
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDishService, OrderDishService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<IOrderAmountCalculator, OrderAmountCalculator>();
builder.Services.AddSingleton<IValidationService, ValidationService>();
builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
