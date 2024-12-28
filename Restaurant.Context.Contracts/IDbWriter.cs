using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Context.Contracts
{
    /// <summary>
    /// Интерфейс создания и модифиакации записей в хранилище
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IDbWriter<in TEntity> where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        void Add([NotNull] TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        void Update([NotNull] TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Delete([NotNull] TEntity entity);

        void HardDelete([NotNull] TEntity entities);

	}
}
