using Examination.Domain.SeedWork;
using Examination.Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Domain.AggregateModels.CategoryAggregate
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task<PagedList<Category>> GetCategoriesPagingAsync(string searchKeyword, int pageIndex, int pageSize);

        Task<Category> GetCategoriesByIdAsync(string id);

        Task<Category> GetCategoriesByNameAsync(string name);

        Task<List<Category>> GetAllCategoriesAsync();
    }
}
