using AutoMapper;
using Examination.Domain.AggregateModels.QuestionAggregate;
using Examination.Dtos.Categories;
using Examination.Shared.Questions;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Examination.Application.Commands.V1.Questions.CreateQuestion
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
            var itemToAdd = await _questionRepository.GetQuestionsByIdAsync(request.Content);
            if (itemToAdd != null)
            {
                _logger.LogError($"Item name existed: {request.Content}");
                return null;

            }
            var questionId = ObjectId.GenerateNewId().ToString();
            var answers = _mapper.Map<List<AnswerDto>, List<Answer>>(request.Answers);
            itemToAdd = new Question(questionId,
                                    request.Content,
                                    request.QuestionType,
                                    request.Level,
                                    request.CategoryId,
                                    answers,
                                    request.Explain, null);
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
