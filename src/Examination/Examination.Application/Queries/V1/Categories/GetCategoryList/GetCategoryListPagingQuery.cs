using Examination.Dtos.Categories;
using Examination.Dtos.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Application.Queries.V1.Categories.GetCategoryList
{
    public class GetCategoryListPagingQuery : IRequest<PagedList<CategoryDto>>
    {
        public string SearchKeyword { get; set; }
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
