using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.PackingListServices.Exceptions
{
    /// <summary>
    /// Ошибка выполнение опрерации
    /// </summary>
    public class OperationModelException : ModelException
    {
        /// <summary>
        /// ctor
        /// </summary>
        public OperationModelException(string message) : base(message) 
        {

        }
    }
}
