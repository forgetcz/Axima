using Domain.Abstraction;
using Infrastrucure.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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
    //[InheritedExport(typeof(IBaseDbRepository<,>))]
    public interface IBaseDbRepository<T, K> where T : BaseEntity<K>
    {
        Task<T> ReadById(K id);
        Task<IEnumerable<T>> ReadAll();
        Task<T> Insert(T entity);
        Task<IEnumerable<T>> InsertMany(IEnumerable<T> entities);
        Task<T> Update(T entity);
        Task<IEnumerable<T>> UpdateMany(IEnumerable<T> entities);
        Task<T> Delete(T entity);
        Task DeleteMany(IEnumerable<T> entities);


    }
}
