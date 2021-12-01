using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Framework.Infrastructure
{
    public interface IRepository<in TKey,T> where T : DomainBase<TKey>
    {
        T GetBy(TKey id);
        List<T> GetAll();
        void Add(T entity);
        bool IsExists(Expression<Func<T,bool>> expression);
    }
}
