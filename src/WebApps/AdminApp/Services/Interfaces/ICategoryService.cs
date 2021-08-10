using Examination.Dtos.Categories;
using Examination.Dtos.SeedWork;
using System.Threading.Tasks;

namespace AdminApp.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<PagedList<CategoryDto>> GetListPaging(CategorySearch taskListSearch);
        Task<CategoryDto> GetDetail(string id);
        Task<bool> Create(CategoryRequest request);
        Task<bool> Update(string id, CategoryRequest request);
        Task<bool> Delete(string id);
    }
}
