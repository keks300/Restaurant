using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Produces
{
    /// <summary>
    /// 
    /// </summary>
    public class ProducesNotFoundAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public ProducesNotFoundAttribute()
            : base(typeof(ErrorModel), StatusCodes.Status404NotFound)
        {

        }
    }
}
