using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<TEntity> TableNoTracking { get; }
        void Add(TEntity entity);
        //Task<TEntity> GetByMaAsync(string ma, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes);
        //Task<TEntity> GetByIdAsync(long id, Func<TEntity, IIncludableQueryable<TEntity, object>> includes);
    }
}
