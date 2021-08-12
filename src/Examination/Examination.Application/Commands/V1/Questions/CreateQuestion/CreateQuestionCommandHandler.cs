using AutoMapper;
using Examination.Application.Commands.V1.Questions.CreateQuestion;
using Examination.Domain.AggregateModels.QuestionAggregate;
using Examination.Dtos.Questions;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Examination.Application.Commands.V1.Categories.CreateQuestion
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, QuestionDto>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateQuestionCommandHandler> _logger;

        public CreateQuestionCommandHandler(
                IQuestionRepository QuestionRepository,
                ILogger<CreateQuestionCommandHandler> logger,
                 IMapper mapper
            )
        {
            _questionRepository = QuestionRepository;
            _logger = logger;
            _mapper = mapper;

        }

        public async Task<QuestionDto> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var itemToAdd = await _questionRepository.GetQuestionsByNameAsync(request.Name);
            if (itemToAdd != null)
            {
                _logger.LogError($"Item name existed: {request.Name}");
                return null;
            }
            itemToAdd = new Question(ObjectId.GenerateNewId().ToString(), request.Name, request.UrlPath);
            try
            {
                await _questionRepository.InsertAsync(itemToAdd);
                return _mapper.Map<Question, QuestionDto>(itemToAdd);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
