using Examination.Shared.Categories;
using Examination.Shared.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Application.Queries.V1.Categories.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<ApiResult<List<CategoryDto>>>
    {
    }
}
