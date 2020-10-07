using DAS.Application.Interfaces;
using DAS.Application.Models.CustomModels;
using DAS.Domain.Interfaces;
using DAS.Domain.Interfaces.DAS;
using DAS.Domain.Models.DAS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAS.Application.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IDasRepositoryWrapper dasRepository) : base(dasRepository)
        {
        }

        public async Task<ServiceResult> Create(User user)
        {
            await _dasRepo.User.Create(user);
            await _dasRepo.SaveAync();
            return new ServiceResultSucess("Created Successfully");
        }

        public async Task<ServiceResult> Delete(long id)
        {
            var user = await _dasRepo.User.Get(id);
            await _dasRepo.User.Delete(user);
            await _dasRepo.SaveAync();
            if (user == null)
                return new ServiceResultError("User is not Exist!!");

            return new ServiceResultSucess($"{user.Name} is deleted!");
        }

        public async Task<User> Get(object id)
        {
            return await _dasRepo.User.Get(id);
        }

        public async Task<IEnumerable<User>> Gets()
        {
            return await _dasRepo.User.Gets();
        }

        public async Task<bool> IsEmailExist(string email)
        {
            return await _dasRepo.User.IsEmailExist(email);
        }

        public async Task<ServiceResult> Update(User user)
        {
            await _dasRepo.User.Update(user);
            await _dasRepo.SaveAync();
            return new ServiceResultSucess("Add User suceess!");
        }
    }
}