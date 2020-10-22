using DAS.Domain.Interfaces;
using DAS.Domain.Models.DAS;
using DAS.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAS.Infrastructure.Repositories
{
    public class UserRepository : DasBaseRepository<User>, IUserRepository
    {
        public UserRepository(DASContext repositoryContext)
            : base(repositoryContext)
        {
        }

        //public async Task<bool> IsEmailExist(string email)
        //{
        //    return await DasContext.User.AnyAsync(s => s.Email == email);
        //}
    }
}