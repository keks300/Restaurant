using Restaurant.Context.Contracts;
using Restaurant.Contracts.Model;

namespace Restaurant.Repositories.Contracts
{
	public interface IWriteRepository<T> : IDbWriter<T> where T : class
	{
	}
}

