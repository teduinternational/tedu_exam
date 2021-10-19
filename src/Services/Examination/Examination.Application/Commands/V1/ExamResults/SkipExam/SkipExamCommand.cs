using System;
using Examination.Shared.ExamResults;
using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Commands.V1.Exams.SkipExam
{
    public class SkipExamCommand : IRequest<ApiResult<bool>>
    {
        public string ExamResultId { get; set; }
    }
}