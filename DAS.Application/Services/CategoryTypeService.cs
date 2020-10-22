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
    public class CategoryTypeService : BaseService, ICategoryTypeServices
    {
        public CategoryTypeService(IDasRepositoryWrapper dasRepository) : base(dasRepository)
        {
        }

        public async Task<ServiceResult> Create(CategoryType category)
        {
            await _dasRepo.CategoryType.InsertAsync(category);
            await _dasRepo.SaveAync();
            return new ServiceResultSucess("Created Successfully");
        }

        public async Task<ServiceResult> Delete(object id)
        {
            var categoryType = await _dasRepo.CategoryType.GetAsync(id);
            await _dasRepo.CategoryType.DeleteAsync(categoryType);
            await _dasRepo.SaveAync();
            if (categoryType == null)
                return new ServiceResultError("User is not Exist!!");

            return new ServiceResultSucess($"{categoryType.Name} is deleted!");
        }

        public async Task<CategoryType> Get(object id)
        {
            return await _dasRepo.CategoryType.GetAsync(id);
        }

        public async Task<IEnumerable<CategoryType>> Gets()
        {
            return await _dasRepo.CategoryType.GetAllListAsync();
        }

        public async Task<ServiceResult> Update(CategoryType categoryType)
        {
            await _dasRepo.CategoryType.UpdateAsync(categoryType);
            await _dasRepo.SaveAync();
            return new ServiceResultSucess("Add category suceess!");
        }
    }
}