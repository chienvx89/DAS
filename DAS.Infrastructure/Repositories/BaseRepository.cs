using DAS.Domain.Interfaces;
using DAS.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAS.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DASContext Context { get; set; }

        public BaseRepository(DASContext repositoryContext)
        {
            Context = repositoryContext;
        }

        public async Task<IEnumerable<T>> Gets()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<T> Get(long id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> Create(T entity)
        {
            var x = await Context.Set<T>().AddAsync(entity);
            return x.Entity;
        }

        public async Task Update(T entity)
        {
            await Task.Run(() =>
            {
                Context.Set<T>().Update(entity);
            });
        }

        public async Task Delete(T entity)
        {
            await Task.Run(() =>
            {
                Context.Set<T>().Remove(entity);
            });
        }

        public async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().AnyAsync(expression);
        }
    }
}