using DAS.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAS.Infrastructure.Repositories.DAS
{
    public class DasBaseRepository<T> : BaseRepository<T> where T : class
    {
        protected DASContext DasContext { get; set; }

        public DasBaseRepository(DASContext repositoryContext) : base(repositoryContext)
        {
            DasContext = (DASContext)base.Context;
        }
    }
}