using Examination.Shared.Categories;
using Examination.Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ApiResult<PagedList<CategoryDto>>> GetCategoriesPagingAsync(CategorySearch taskListSearch);
        Task<ApiResult<CategoryDto>> GetCategoryByIdAsync(string id);
        Task<bool> CreateAsync(CreateCategoryRequest request);
        Task<bool> UpdateAsync(UpdateCategoryRequest request);
        Task<bool> DeleteAsync(string id);
        Task<ApiResult<List<CategoryDto>>> GetAllCategoriesAsync();

    }
}
