using DAS.Domain.Models.DAS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAS.Application.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        Task<bool> IsEmailExist(string email);
    }
}