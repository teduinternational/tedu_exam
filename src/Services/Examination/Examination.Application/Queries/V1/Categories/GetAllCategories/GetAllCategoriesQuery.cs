using Examination.Dtos.SeedWork;
using Examination.Shared.Categories;
using Examination.Shared.SeedWork;
using MediatR;
using System.Collections.Generic;

namespace Examination.Application.Queries.V1.Categories.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<ApiResult<List<CategoryDto>>>
    {
    }
}
