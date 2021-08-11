using Examination.Dtos.Categories;
using Examination.Dtos.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<PagedList<CategoryDto>> GetCategoriesPagingAsync(CategorySearch taskListSearch);
        Task<CategoryDto> GetCategoryByIdAsync(string id);
        Task<bool> CreateAsync(CreateCategoryRequest request);
        Task<bool> UpdateAsync(UpdateCategoryRequest request);
        Task<bool> DeleteAsync(string id);
    }
}
