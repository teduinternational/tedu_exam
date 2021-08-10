using Examination.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Domain.AggregateModels.CategoryAggregate
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task<Tuple<List<Category>, long>> GetCategoryListPaging(string searchKeyword, int pageIndex, int pageSize);
    }
}
