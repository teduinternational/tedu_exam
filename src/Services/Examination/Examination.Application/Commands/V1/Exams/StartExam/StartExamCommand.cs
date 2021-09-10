using System;
using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Commands.V1.Exams.StartExam
{
    public class StartExamCommand : IRequest<ApiResult<bool>>
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ExamId { get; set; }

        public DateTime StartDate { get; set; }
    }
}