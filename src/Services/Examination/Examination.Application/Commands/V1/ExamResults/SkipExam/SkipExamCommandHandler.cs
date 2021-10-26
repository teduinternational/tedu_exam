using System.Threading;
using System.Threading.Tasks;
using Examination.Application.Commands.V1.Exams.SkipExam;
using Examination.Domain.AggregateModels.ExamResultAggregate;
using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Commands.V1.Exams.StartExam
{
    public class SkipExamCommandHandler : IRequestHandler<SkipExamCommand, ApiResult<bool>>
    {
        private readonly IExamResultRepository _examResultRepository;
        public SkipExamCommandHandler(
            IExamResultRepository examResultRepository)
        {
            _examResultRepository = examResultRepository;
        }
        public async Task<ApiResult<bool>> Handle(SkipExamCommand request, CancellationToken cancellationToken)
        {
            var examResult = await _examResultRepository.GetDetails(request.ExamResultId);
            if (examResult == null)
                return new ApiResult<bool>(400, false, "Cannot found");

            await _examResultRepository.DeleteAsync(request.ExamResultId);
            return new ApiSuccessResult<bool>(200, true);
        }
    }
}