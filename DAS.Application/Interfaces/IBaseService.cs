using DAS.Application.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAS.Application.Interfaces
{
    public interface IBaseService<TEntity>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> Gets();

        Task<TEntity> Get(object id);

        Task<ServiceResult> Create(TEntity user);

        Task<ServiceResult> Update(TEntity user);

        Task<ServiceResult> Delete(object id);
    }
}