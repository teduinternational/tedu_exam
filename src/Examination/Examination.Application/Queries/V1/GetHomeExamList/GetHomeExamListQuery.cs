using System.Collections.Generic;
using Examination.Dtos;
using MediatR;

namespace Examination.Application.Queries.GetHomeExamList
{
    public class GetHomeExamListQuery : IRequest<IEnumerable<ExamDto>>
    {

    }
}