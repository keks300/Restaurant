using Restaurant.PackingListServices.Exceptions;

namespace Restaurant.PackingListServices.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidateModelException : ModelException
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<(string, string)> Errors { get;set; }

        /// <summary>
        /// ctor
        /// </summary>
        public ValidateModelException(IEnumerable<(string, string)> errors) 
            : base("Ошибка валидации")
        {
            Errors = errors;
        }
    }
}
