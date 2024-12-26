using Restaurant.Contracts.Model;

namespace Restaurant.Repositories.Contracts
{
	/// <summary>
	/// 
	/// </summary>
	public interface IReadRepository<T> where T : class
{
    /// <summary>
    /// Получает объект типа <typeparamref name="T"/> по указанному идентификатору
    /// </summary>
    Task<T?> GetById(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Получает список всех действующих объектов типа <typeparamref name="T"/>
    /// </summary>
    Task<IReadOnlyCollection<T>> GetAll(CancellationToken cancellationToken);
}

}
