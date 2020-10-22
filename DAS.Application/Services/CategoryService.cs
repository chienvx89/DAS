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
    public class CategoryService : BaseService, ICategoryServices
    {
        public CategoryService(IDasRepositoryWrapper dasRepository) : base(dasRepository)
        {
        }

        public async Task<ServiceResult> Create(Category category)
        {
            await _dasRepo.Category.InsertAsync(category);
            await _dasRepo.SaveAync();
            return new ServiceResultSucess("Created Successfully");
        }

        public async Task<ServiceResult> Delete(object id)
        {
            var category = await _dasRepo.Category.GetAsync(id);
            await _dasRepo.Category.DeleteAsync(category);
            await _dasRepo.SaveAync();
            if (category == null)
                return new ServiceResultError("User is not Exist!!");

            return new ServiceResultSucess($"{category.Name} is deleted!");
        }

        public async Task<Category> Get(object id)
        {
            return await _dasRepo.Category.GetAsync(id);
        }

        public async Task<IEnumerable<Category>> Gets()
        {
            return await _dasRepo.Category.GetAllListAsync();
        }

        public async Task<ServiceResult> Update(Category category)
        {
            await _dasRepo.Category.UpdateAsync(category);
            await _dasRepo.SaveAync();
            return new ServiceResultSucess("Add category suceess!");
        }
    }
}