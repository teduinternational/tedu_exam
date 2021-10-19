using AutoMapper;
using Examination.Application.Extensions;
using Examination.Domain.AggregateModels.CategoryAggregate;
using Examination.Domain.AggregateModels.ExamAggregate;
using Examination.Domain.AggregateModels.QuestionAggregate;
using Examination.Shared.Exams;
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

namespace Examination.Application.Commands.V1.Exams.CreateExam
{
    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, ApiResult<ExamDto>>
    {
        private readonly IExamRepository _examRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateExamCommandHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateExamCommandHandler(
                IExamRepository examRepository,
                IQuestionRepository questionRepository,
                ILogger<CreateExamCommandHandler> logger,
                 IMapper mapper,
                 IHttpContextAccessor httpContextAccessor,
                 ICategoryRepository categoryRepository
            )
        {
            _examRepository = examRepository;
            _logger = logger;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _categoryRepository = categoryRepository;
            _questionRepository = questionRepository;

        }

        public async Task<ApiResult<ExamDto>> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            var questions = new List<Question>();
            if (request.AutoGenerateQuestion)
            {
                questions = await _questionRepository.GetRandomQuestionsForExamAsync(request.CategoryId, request.Level, request.NumberOfQuestions);
            }
            else
            {
                questions = _mapper.Map<List<QuestionDto>, List<Question>>(request.Questions);
            }

            var category = await _categoryRepository.GetCategoriesByIdAsync(request.CategoryId);
            var currentUserId = _httpContextAccessor.GetUserId();
            var itemToAdd = new Exam(
                request.Name,
                request.ShortDesc,
                request.Content,
                request.NumberOfQuestions,
                request.Duration,
                questions,
                request.Level,
                currentUserId,
                request.NumberOfQuestionCorrectForPass,
                request.IsTimeRestricted,
                request.CategoryId,
                category.Name);

            await _examRepository.InsertAsync(itemToAdd);

            var result = _mapper.Map<Exam, ExamDto>(itemToAdd);

            return new ApiSuccessResult<ExamDto>(200, result);
        }
    }
}