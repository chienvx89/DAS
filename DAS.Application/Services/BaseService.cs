using DAS.Domain.Interfaces;
using DAS.Domain.Interfaces.DAS;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAS.Application.Services
{
    public class BaseService
    {
        protected IDasRepositoryWrapper _dasRepo;

        public BaseService(IDasRepositoryWrapper dasRepository)
        {
            _dasRepo = dasRepository;
        }
    }
}