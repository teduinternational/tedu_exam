using Examination.Domain.AggregateModels.ExamResultAggregate;
using Examination.Shared.ExamResults;
using Examination.Shared.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Application.Queries.V1.ExamResults.GetExamResultsByUserIdPaging
{
    public class GetExamResultsByUserIdPagingQuery : IRequest<ApiResult<PagedList<ExamResultDto>>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
