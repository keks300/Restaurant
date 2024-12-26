using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Context.Contracts
{
    public interface IReader
    {
        /// <summary>
        /// Предоставляет функциональные возможности для выполнения запросов
        /// </summary>
        IQueryable<TEntity> Read<TEntity>() where TEntity : class;
    }
}
