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
        Task CreateRange(IEnumerable<T> entityList);
        Task<IEnumerable<T>> ReadAll(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> PagingReadAll(int page);
        Task<IEnumerable<T>> PagingReadAll(int page, string includeProperty);
        Task<IEnumerable<T>> PagingReadAll(Expression<Func<T, bool>> predicate, int page);
        Task<IEnumerable<T>> PagingReadAll(Expression<Func<T, bool>> predicate, int page, string includeProperty);
        Task<T> Read(Expression<Func<T, bool>> predicate);
        Task<T> Read(Expression<Func<T, bool>> predicate, string includeProperty);
        Task<T> Read(int id);
        Task Update(T entity);
        Task Delete(int id);
        Task Delete(T entity);
        Task SaveChanges();
    }
}
