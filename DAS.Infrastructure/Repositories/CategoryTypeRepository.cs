using DAS.Domain.Interfaces;
using DAS.Domain.Models.DAS;
using DAS.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAS.Infrastructure.Repositories
{
    public class CategoryTypeRepository : BaseRepository<CategoryType>, ICategoryTypeRepository
    {
        public CategoryTypeRepository(DASContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Task<bool> GetPaging()
        {
            throw new NotImplementedException();
        }
    }
}