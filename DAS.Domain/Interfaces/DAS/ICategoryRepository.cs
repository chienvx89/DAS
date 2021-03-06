﻿using DAS.Domain.Models.DAS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAS.Domain.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<bool> GetPaging();
    }
}