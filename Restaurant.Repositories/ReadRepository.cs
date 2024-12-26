using Microsoft.EntityFrameworkCore;
using Restaurant.Context.Contracts;
using Restaurant.Contracts.Model;
using Restaurant.Repositories.Contracts;
using Restaurant.Context.Contracts.Specs;

namespace Restaurant.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : class, ISoftDeleted, IEntityWithId
    {
        private readonly IReader reader;

        public ReadRepository(IReader reader)
        {
            this.reader = reader;
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAll(CancellationToken cancellationToken)
            => await reader.Read<TEntity>()
            .NotDeleted()
            .ToListAsync(cancellationToken);

        public Task<TEntity?> GetById(Guid id, CancellationToken cancellationToken)
            => reader.Read<TEntity>()
                .NotDeleted() // Теперь это работает, так как TEntity реализует ISoftDeleted
                .GetById(id)  // Теперь это работает, так как TEntity реализует IEntityWithId
                .FirstOrDefaultAsync(cancellationToken);
    }
}
