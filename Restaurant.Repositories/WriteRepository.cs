using Restaurant.Common.Abstractions;
using Restaurant.Context.Contracts;
using Restaurant.Contracts.Model;
using Restaurant.Repositories.Contracts;

namespace Restaurant.Repositories
{
    public class WriteRepository<TEntity> : BaseWriteRepository<TEntity>, IWriteRepository<TEntity> where TEntity : class
    {
        public WriteRepository(IWriter writer, IDateTimeProvider dateTimeProvider)
            : base(writer, dateTimeProvider)
        {

        }
    }

}
