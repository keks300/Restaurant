using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Context.Contracts
{
    public interface IWriter
    {
        /// <summary>
        /// Добавить новую запись
        /// </summary>
        void Add<TEntity>([NotNull] TEntity entity) where TEntity : class;

        /// <summary>
        /// Изменить запись
        /// </summary>
        void Update<TEntity>([NotNull] TEntity entity) where TEntity : class;

        /// <summary>
        /// Удалить запись
        /// </summary>
        void Delete<TEntity>([NotNull] TEntity entity) where TEntity : class;
    
       // void Delete<TEntity>([NotNull] IEnumerable<TEntity> entities) where TEntity : class;

	}
}
