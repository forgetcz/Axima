using Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Interfaces
{
    /// <summary>
    /// Base definition for each database respository action on database item
    /// </summary>
    /// <typeparam name="T">Type of entity</typeparam>
    /// <typeparam name="K">Type of key in database</typeparam>
    public interface IBaseDbRepository<T, K> where T : BaseEntity
    {
        Task<T> ReadById(K id);
        Task<IEnumerable<T>> ReadAll();

        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
