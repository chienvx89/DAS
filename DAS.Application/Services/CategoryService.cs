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
            await _dasRepo.Category.Create(category);
            await _dasRepo.SaveAync();
            return new ServiceResultSucess("Created Successfully");
        }

        public async Task<ServiceResult> Delete(object id)
        {
            var category = await _dasRepo.Category.Get(id);
            await _dasRepo.Category.Delete(category);
            await _dasRepo.SaveAync();
            if (category == null)
                return new ServiceResultError("User is not Exist!!");

            return new ServiceResultSucess($"{category.Name} is deleted!");
        }

        public async Task<Category> Get(object id)
        {
            return await _dasRepo.Category.Get(id);
        }

        public async Task<IEnumerable<Category>> Gets()
        {
            return await _dasRepo.Category.Gets();
        }

        public async Task<ServiceResult> Update(Category category)
        {
            await _dasRepo.Category.Update(category);
            await _dasRepo.SaveAync();
            return new ServiceResultSucess("Add category suceess!");
        }
    }
}