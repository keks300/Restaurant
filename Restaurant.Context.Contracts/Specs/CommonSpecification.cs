using Restaurant.Context.Contracts;

namespace Restaurant.Context.Contracts.Specs
{
	public static class CommonSpecification
    {
        public static IQueryable<T> NotDeleted<T>(this IQueryable<T> set)
            where T : ISoftDeleted
            => set.Where(x => x.Deleted == null);

        public static IQueryable<T> GetById<T>(this IQueryable<T> set, Guid id)
            where T : IEntityWithId
            => set.Where(x => x.Id == id);
    }
}
