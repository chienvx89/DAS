using DAS.Domain.Interfaces;
using DAS.Domain.Models.DAS;
using DAS.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAS.Infrastructure.Repositories.DAS
{
    public class CategoryRepository : DasBaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DASContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Task<bool> GetPaging()
        {
            throw new NotImplementedException();
        }
    }
}