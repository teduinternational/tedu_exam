using AutoMapper;
using Examination.Domain.AggregateModels.ExamAggregate;
using Examination.Domain.AggregateModels.ExamResultAggregate;
using Examination.Shared.ExamResults;
using Examination.Shared.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Examination.Application.Commands.V1.Exams.FinishExam
{
    public class FinishExamCommandHandler : IRequestHandler<FinishExamCommand, ApiResult<ExamResultDto>>
    {
        private readonly IExamResultRepository _examResultRepository;
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;
        public FinishExamCommandHandler(
            IExamResultRepository examResultRepository,
            IExamRepository examRepository,
            IMapper mapper)
        {
            _examResultRepository = examResultRepository;
            _examRepository = examRepository;
            _mapper = mapper;
        }
        public async Task<ApiResult<ExamResultDto>> Handle(FinishExamCommand request, CancellationToken cancellationToken)
        {
            var examResult = await _examResultRepository.GetDetails(request.ExamResultId);
            var exam = await _examRepository.GetExamByIdAsync(examResult.ExamId);
            if (exam.IsTimeRestricted && DateTime.UtcNow > examResult.ExamFinishDate)
            {
                return new ApiResult<ExamResultDto>(400, false, "Your exam was exessed limit time.");
            }
            examResult.CorrectQuestionCount = 0;
            foreach (var item in examResult.QuestionResults)
            {
                var question = exam.Questions.FirstOrDefault(x => x.Id == item.Id);
                if (question != null)
                {
                    var correctAnswers = question.Answers.Where(x => x.IsCorrect == true).Select(x => x.Id);
                    var userAnswers = item.Answers.Where(x => x.UserChosen == true).Select(x => x.Id);
                    IEnumerable<string> inFirstOnly = correctAnswers.Except(userAnswers);
                    IEnumerable<string> inSecondOnly = userAnswers.Except(correctAnswers);
                    bool allInBoth = !inFirstOnly.Any() && !inSecondOnly.Any();
                    if (allInBoth)
                    {
                        examResult.CorrectQuestionCount += 1;
                        item.Result = true;
                    }
                    else
                    {
                        item.Result = false;
                    }

                }
            }
            examResult.Passed = examResult.CorrectQuestionCount >= exam.NumberOfQuestionCorrectForPass ? true : false;
            examResult.Finished = true;

            await _examResultRepository.UpdateAsync(examResult);
            var dto = _mapper.Map<ExamResultDto>(examResult);
            return new ApiSuccessResult<ExamResultDto>(200, dto);
        }
    }
}