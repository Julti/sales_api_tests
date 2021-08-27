using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SalesApi
{
    interface IRepository
    {
        public interface IRepository<T> where T : class, new()
        {
            Task<T> Add(T newEntity);
            Task<List<T>> Add(List<T> newEntities);
            Task<T> Update(T modifiedTEntity);
            Task<List<T>> Update(List<T> newEntities);
            Task<T> Delete(T deleteTEntity);
            Task Delete(Expression<Func<T, bool>> criteria);
            Task<T> Find(int id);
            Task<List<T>> Get();
            Task<List<T>> Get(Expression<Func<T, bool>> criteria);
        }
    }
}
