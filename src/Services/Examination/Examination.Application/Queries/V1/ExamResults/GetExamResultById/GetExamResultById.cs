using Examination.Shared.ExamResults;
using Examination.Shared.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Application.Queries.V1.ExamResults.GetExamResultById
{
    public class GetExamResultByIdQuery : IRequest<ApiResult<ExamResultDto>>
    {
        public GetExamResultByIdQuery(string id)
        {
            Id = id;
        }
        public string Id { set; get; }
    }
}