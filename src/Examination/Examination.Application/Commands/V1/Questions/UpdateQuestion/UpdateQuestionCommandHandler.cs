using Examination.Application.Commands.V1.Categories.UpdateQuestion;
using Examination.Domain.AggregateModels.QuestionAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Examination.Application.Commands.V1.Questions.UpdateQuestion
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, bool>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ILogger<UpdateQuestionCommandHandler> _logger;

        public UpdateQuestionCommandHandler(
                IQuestionRepository QuestionRepository,
                ILogger<UpdateQuestionCommandHandler> logger
            )
        {
            _questionRepository = QuestionRepository;
            _logger = logger;

        }

        public async Task<bool> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _questionRepository.GetQuestionsByIdAsync(request.Id);
            if (itemToUpdate == null)
            {
                _logger.LogError($"Item is not found {request.Id}");
                return false;
            }

            itemToUpdate.Name = request.Name;
            itemToUpdate.UrlPath = request.UrlPath;
            try
            {
                await _questionRepository.UpdateAsync(itemToUpdate);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                throw;
            }

            return true;
        }
    }
}
