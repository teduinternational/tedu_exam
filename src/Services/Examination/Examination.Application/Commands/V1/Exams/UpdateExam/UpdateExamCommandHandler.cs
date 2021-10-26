using AutoMapper;
using Examination.Domain.AggregateModels.CategoryAggregate;
using Examination.Domain.AggregateModels.ExamAggregate;
using Examination.Domain.AggregateModels.QuestionAggregate;
using Examination.Shared.Questions;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Examination.Application.Commands.V1.Exams.UpdateExam
{
    public class UpdateExamCommandHandler : IRequestHandler<UpdateExamCommand, ApiResult<bool>>
    {
        private readonly IExamRepository _examRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<UpdateExamCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateExamCommandHandler(
                IExamRepository examRepository,
                IQuestionRepository questionRepository,
                ICategoryRepository categoryRepository,
                ILogger<UpdateExamCommandHandler> logger, IMapper mapper
            )
        {
            _examRepository = examRepository;
            _questionRepository = questionRepository;
            _categoryRepository = categoryRepository;
            _logger = logger;
            _mapper = mapper;

        }

        public async Task<ApiResult<bool>> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _examRepository.GetExamByIdAsync(request.Id);
            if (itemToUpdate == null)
            {
                _logger.LogError($"Item is not found {request.Id}");
                return new ApiErrorResult<bool>(400, $"Item is not found {request.Id}");
            }

            if (request.NumberOfQuestions != itemToUpdate.NumberOfQuestions)
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
                itemToUpdate.Questions = questions;

            }

            if (itemToUpdate.Questions.Count < request.NumberOfQuestionCorrectForPass)
            {
                return new ApiErrorResult<bool>(400, "Number of questions is not engough for required");
            }


            if (request.CategoryId != itemToUpdate.CategoryId)
            {
                var category = await _categoryRepository.GetCategoriesByIdAsync(request.CategoryId);
                itemToUpdate.CategoryId = category.Id;
                itemToUpdate.CategoryName = category.Name;
            }

            itemToUpdate.Name = request.Name;
            itemToUpdate.ShortDesc = request.ShortDesc;
            itemToUpdate.Content = request.Content;
            itemToUpdate.Duration = request.Duration;
            itemToUpdate.Level = request.Level;
            itemToUpdate.IsTimeRestricted = request.IsTimeRestricted;
            itemToUpdate.NumberOfQuestionCorrectForPass = request.NumberOfQuestionCorrectForPass;
            itemToUpdate.NumberOfQuestions = request.NumberOfQuestions;

            await _examRepository.UpdateAsync(itemToUpdate);
            return new ApiSuccessResult<bool>(200, true, "Update successful");
        }
    }
}