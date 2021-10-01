using Examination.Shared.Exams;
using Examination.Shared.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Application.Queries.V1.Exams.GetAllExams
{
    public class GetAllExamsQuery : IRequest<ApiResult<IEnumerable<ExamDto>>>
    {
        public GetAllExamsQuery()
        {
        }
    }
}
