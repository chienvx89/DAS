using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAS.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> Gets();

        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression);

        Task<T> Get(object id);

        Task<T> Create(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task<bool> Any(Expression<Func<T, bool>> expression);
    }
}