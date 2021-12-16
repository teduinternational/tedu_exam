using AutoMapper;
using Examination.Application.Extensions;
using Examination.Domain.AggregateModels.QuestionAggregate;
using Examination.Shared.Questions;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Examination.Application.Commands.V1.Questions.CreateQuestion
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, ApiResult<QuestionDto>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateQuestionCommandHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateQuestionCommandHandler(
                IQuestionRepository QuestionRepository,
                ILogger<CreateQuestionCommandHandler> logger,
                 IMapper mapper,
                 IHttpContextAccessor httpContextAccessor
            )
        {
            _questionRepository = QuestionRepository;
            _logger = logger;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<QuestionDto>> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            if(request.Answers.Count(x=>x.IsCorrect)> 1 && request.QuestionType== Shared.Enums.QuestionType.SingleSelection)
            {
                return new ApiErrorResult<QuestionDto>("Single choice question cannot have multiple correct answers.");
            }
            var questionId = ObjectId.GenerateNewId().ToString();
            var answers = _mapper.Map<List<AnswerDto>, List<Answer>>(request.Answers);

            var itemToAdd = new Question(questionId,
                                     request.Content,
                                     request.QuestionType,
                                     request.Level,
                                     request.CategoryId,
                                     answers,
                                     request.Explain, _httpContextAccessor.GetUserId());
            try
            {
                await _questionRepository.InsertAsync(itemToAdd);
                var result = _mapper.Map<Question, QuestionDto>(itemToAdd);
                return new ApiSuccessResult<QuestionDto>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
