using Examination.Domain.AggregateModels.ExamAggregate;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Examination.Application.Commands.V1.Exams.DeleteExam
{
    public class DeleteExamCommandHandler : IRequestHandler<DeleteExamCommand, ApiResult<bool>>
    {
        private readonly IExamRepository _examRepository;
        private readonly ILogger<DeleteExamCommandHandler> _logger;

        public DeleteExamCommandHandler(
                IExamRepository examRepository,
                ILogger<DeleteExamCommandHandler> logger
            )
        {
            _examRepository = examRepository;
            _logger = logger;

        }

        public async Task<ApiResult<bool>> Handle(DeleteExamCommand request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _examRepository.GetExamByIdAsync(request.Id);
            if (itemToUpdate == null)
            {
                _logger.LogError($"Item is not found {request.Id}");
                return new ApiErrorResult<bool>(400, $"Item is not found {request.Id}");
            }

            await _examRepository.DeleteAsync(request.Id);
            return new ApiSuccessResult<bool>(200, true, "Delete successful");
        }
    }
}