using Restaurant.Common.Abstractions;

namespace Restaurant.Common
{
	/// <summary>
	/// 
	/// </summary>
	public class DateTimeProvider : IDateTimeProvider
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset Now => DateTimeOffset.Now;

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}
