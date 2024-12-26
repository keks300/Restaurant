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
    public abstract class ModelException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ModelException(string message)
            : base(message)
        { }
    }
}
