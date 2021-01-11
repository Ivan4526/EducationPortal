using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        IEnumerable<T> ReadAll();
        T Read(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        void Delete(T entity);
    }
}
