using Examination.Domain.AggregateModels.QuestionAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Examination.Application.Commands.V1.Questions.DeleteQuestion
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, bool>
    {
        private readonly IQuestionRepository _QuestionRepository;
        private readonly ILogger<DeleteQuestionCommandHandler> _logger;

        public DeleteQuestionCommandHandler(
                IQuestionRepository QuestionRepository,
                ILogger<DeleteQuestionCommandHandler> logger
            )
        {
            _QuestionRepository = QuestionRepository;
            _logger = logger;

        }

        public async Task<bool> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _QuestionRepository.GetQuestionsByIdAsync(request.Id);
            if (itemToUpdate == null)
            {
                _logger.LogError($"Item is not found {request.Id}");
                return false;
            }

            try
            {
                await _QuestionRepository.DeleteAsync(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
