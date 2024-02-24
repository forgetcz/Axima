using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstraction
{
    /// <summary>
    /// Base definition for each respository action on database item
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    public interface IBaseRepository<T, K> where T : BaseEntity
    {
        Task<T> ReadById(K id);
        Task<IEnumerable<T>> ReadAll();//Expression<Func<T, bool>> predicate

        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
