using Examination.Shared.Categories;
using Examination.Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApp.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ApiResult<List<CategoryDto>>> GetAllCategoriesAsync();
    }
}
