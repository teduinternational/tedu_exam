using System.Collections.Generic;
using Examination.Dtos.Exams;
using MediatR;

namespace Examination.Application.Queries.GetHomeExamList
{
    public class GetHomeExamListQuery : IRequest<IEnumerable<ExamDto>>
    {

    }
}