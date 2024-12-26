using FluentValidation;
using Restaurant.PackingListServices.Contracts.Model;

namespace Restaurant.PackingListServices.Validators.Dish
{
    /// <summary>
    /// Валидатор для <see cref="DishModel"/>
    /// </summary>
    public class DishModelValidator : AbstractValidator<DishModel>
    {
        /// <summary>
        /// ctor
        /// </summary>
        public DishModelValidator()
        {
            Include(new AddDishModelValidator());
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
