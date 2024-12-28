using Restaurant.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Restaurant.Context.Contracts
{
    public abstract class BaseWriteRepository<T> : IDbWriter<T> where T : class
    {
        private readonly IWriter writer;
        private readonly IDateTimeProvider dateTimeProvider;

        /// <summary>
        /// ctor
        /// </summary>
        protected BaseWriteRepository(IWriter writer, IDateTimeProvider dateTimeProvider)
        {
            this.writer = writer;
            this.dateTimeProvider = dateTimeProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Add([NotNull] T entity)
        {
            if (entity is IEntityWithId entityWithId && entityWithId.Id == default)
            {
                entityWithId.Id = Guid.NewGuid();
            }
            AuditForCreate(entity);
            writer.Add(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Delete([NotNull] T entity)
        {
            AuditForUpdate(entity);
            if (entity is ISoftDeleted softDeletedEntity)
            {
                softDeletedEntity.Deleted = dateTimeProvider.UtcNow;
                writer.Update(entity);
            }
            else
            {
                writer.Delete(entity);
            }
        }

		public void HardDelete([NotNull] T entities)
		{
			writer.Delete(entities);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		public void Update([NotNull] T entity)
        {
			AuditForUpdate(entity);
            writer.Update(entity);
        }

        private void AuditForCreate([NotNull] T entity)
        {
            if (entity is IAuditableEntity auditCreated)
            {
                auditCreated.CreatedAt = dateTimeProvider.UtcNow;
                auditCreated.UpdatedAt = dateTimeProvider.UtcNow;
            }
        }

        private void AuditForUpdate ([NotNull] T entity)
        {
            if (entity is IAuditableEntity auditCreated)
            {
                auditCreated.UpdatedAt = dateTimeProvider.UtcNow;
            }
        }
    }
}
