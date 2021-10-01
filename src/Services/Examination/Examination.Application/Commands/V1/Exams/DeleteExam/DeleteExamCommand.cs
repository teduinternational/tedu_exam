using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Commands.V1.Exams.DeleteExam
{
    public class DeleteExamCommand : IRequest<ApiResult<bool>>
    {
        public DeleteExamCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}