using AutoMapper;
using DAS.Application.Interfaces;
using DAS.Application.Models.CustomModels;
using DAS.Application.Models.ViewModels;
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
        private readonly IMapper _mapper;

        public UserService(IDasRepositoryWrapper dasRepository, IMapper mapper) : base(dasRepository)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResult> Create(User user)
        {
            await _dasRepo.User.InsertAsync(user);
            await _dasRepo.SaveAync();
            return new ServiceResultSucess("Created Successfully");
        }

        public async Task<ServiceResult> Delete(object id)
        {
            var user = await _dasRepo.User.GetAsync(id);
            await _dasRepo.User.DeleteAsync(user);
            await _dasRepo.SaveAync();
            if (user == null)
                return new ServiceResultError("User is not Exist!!");

            return new ServiceResultSucess($"{user.Name} is deleted!");
        }

        public async Task<User> Get(object id)
        {
            return await _dasRepo.User.GetAsync(id);
        }

        public async Task<IEnumerable<User>> Gets()
        {
            return await _dasRepo.User.GetAllListAsync();
        }

        public async Task<bool> IsEmailExist(string email)
        {
            return await _dasRepo.User.AnyAsync(s => s.Email == email);
        }

        public async Task<ServiceResult> Update(User user)
        {
            await _dasRepo.User.UpdateAsync(user);
            await _dasRepo.SaveAync();
            return new ServiceResultSucess("Add User suceess!");
        }
    }
}