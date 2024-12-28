using System.Reflection;
using Microsoft.OpenApi.Models;
using Restaurant.Contracts.Model;

namespace Restaurant.Infrastructure;

/// <summary>
///     Предоставляет фукнционал для регистрации сервисов авто-документирования Swagger
/// </summary>
static internal class SwaggerDocExtensions
{
    /// <summary>
    ///     Регистриует сервис xml документирования
    /// </summary>
    public static void AddSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(
            options =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);


                options.SwaggerDoc($"{nameof(Dish)}", new OpenApiInfo { Title = "Блюдо", Version = "v1", });
				options.SwaggerDoc($"{nameof(Customer)}", new OpenApiInfo { Title = "Покупатель", Version = "v1", });
				options.SwaggerDoc($"{nameof(Order)}", new OpenApiInfo { Title = "Заказ", Version = "v1", });
                options.SwaggerDoc($"{nameof(Delivery)}", new OpenApiInfo { Title = "Доставка", Version = "v1", });
			});
    }

    /// <summary>
    ///     Вносит параметры для UI элементов Swagger
    /// </summary>
    public static void UseSwaggerUI(this WebApplication web)
    {
        web.UseSwaggerUI(
            options =>
            {
				options.SwaggerEndpoint($"{nameof(Dish)}/swagger.json", "Блюдо");
                options.SwaggerEndpoint($"{nameof(Customer)}/swagger.json", "Покупатель");
				options.SwaggerEndpoint($"{nameof(Order)}/swagger.json", "Заказ");
				options.SwaggerEndpoint($"{nameof(Delivery)}/swagger.json", "Доставка");
			});
    }
}
