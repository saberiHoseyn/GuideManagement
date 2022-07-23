using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Framework.Domain
{
    public interface IRepository<Tkey, T> where T : class
    {
        void Create(T entity);
        void Delete(T entity);
        T Get(Tkey id);
        List<T> Get();
        bool Exists(Expression<Func<T, bool>> expression);
        void SaveChanges();
    }
}
