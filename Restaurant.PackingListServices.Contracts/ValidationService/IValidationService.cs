using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.PackingListServices.ValidationService
{
    public interface IValidationService
    {
        /// <summary>
        /// Валидирует модаль <see cref="TModel"/>
        /// </summary>
        void Validate<TModel>(TModel model);
    }
}
