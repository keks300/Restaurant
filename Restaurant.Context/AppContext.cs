using Microsoft.EntityFrameworkCore;
using Restaurant.Context.Contracts;
using System.Diagnostics.CodeAnalysis;
using Restaurant.Contracts.Configurations;


namespace Restaurant.Context
{
	/// <summary>
	/// Контекст приложения
	/// </summary>
	/// <remarks>
	/// dotnet ef migrations add {название миграции}
	/// dotnet tool install --global dotnet-ef
	/// dotnet ef migrations add init --project Restaurant.Context/Restaurant.Context.csproj
	/// dotnet ef database update --project Restaurant.Context/Restaurant.Context.csproj
	/// </remarks>


	public class AppContext : DbContext, IReader, IUnitOfWork, IWriter
	{
        public AppContext(DbContextOptions<AppContext> options) : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IContractAnchor).Assembly);
        }

        IQueryable<TEntity> IReader.Read<TEntity>()
            => base.Set<TEntity>()
            .AsNoTracking()
            .AsQueryable();

        async Task<int> IUnitOfWork.CommitAsync(CancellationToken cancellationToken)
        {
            var count = await base.SaveChangesAsync(cancellationToken);
            foreach (var enrty in base.ChangeTracker.Entries().ToArray())
            {
                enrty.State = EntityState.Detached;
            }

            return count;
        }

        void IWriter.Add<TEntity>([NotNull] TEntity entity)
            => base.Entry(entity).State = EntityState.Added;

        void IWriter.Update<TEntity>([NotNull] TEntity entity)
            => base.Entry(entity).State = EntityState.Modified;

        void IWriter.Delete<TEntity>([NotNull] TEntity entity)
            => base.Entry(entity).State = EntityState.Deleted;

	}
}
