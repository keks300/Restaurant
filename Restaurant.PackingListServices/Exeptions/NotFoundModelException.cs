using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.PackingListServices.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class NotFoundModelException : ModelException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public NotFoundModelException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId"></param>
        public NotFoundModelException(Guid entityId)
            : base($"Не удалось найти сущность с идентификатором '{entityId}'")
        {

        }
    }
}
