using FluentValidation;
using Restaurant.PackingListServices.Contracts.Model;

namespace Restaurant.PackingListServices.Validators.Dish
{
    /// <summary>
    /// 
    /// </summary>
    public class AddDishModelValidator : AbstractValidator<AddDishModel>
    {
        private const int MaxDataBaseString = 255;
        private const int MinDataBaseString = 3;
        /// <summary>
        /// ctr
        /// </summary>
        public AddDishModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(MinDataBaseString, MaxDataBaseString);
            RuleFor(x => x.Description).MaximumLength(MaxDataBaseString);
        }
    }
}
