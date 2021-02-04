using Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task Create(T entity);
        Task<IEnumerable<T>> ReadAll();
        Task<IEnumerable<T>> ReadAll(Expression<Func<T, bool>> predicate);
        Task<T> Read(Expression<Func<T, bool>> predicate);
        Task<T> Read(int id);
        Task Update(T entity);
        Task Delete(int id);
    }
}
