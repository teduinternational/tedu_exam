using System;
using Examination.Shared.ExamResults;
using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Commands.V1.Exams.FinishExam
{
    public class FinishExamCommand : IRequest<ApiResult<ExamResultDto>>
    {
        public string ExamResultId { get; set; }
    }
}