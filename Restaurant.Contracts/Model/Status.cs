using System.Runtime.Serialization;

namespace Restaurant.Contracts
{
	/// <summary>
	/// Статусы доствки
	/// </summary>
	public enum Status
	{

		/// <summary>
		/// Ожидаемый
		/// </summary>
		Pending = 1,
		
		/// <summary>
		/// В процессе
		/// </summary>
		InProgress = 2,

		/// <summary>
		/// Завершенный
		/// </summary>
		Completed = 3,

		/// <summary>
		/// Отменненный
		/// </summary>
		Cancel = 4,
	}
}
