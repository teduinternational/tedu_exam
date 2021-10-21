using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Examination.Application.Extensions;
using Examination.Domain.AggregateModels.ExamAggregate;
using Examination.Domain.AggregateModels.ExamResultAggregate;
using Examination.Shared.ExamResults;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Examination.Application.Commands.V1.Exams.StartExam
{
    public class StartExamCommandHandler : IRequestHandler<StartExamCommand, ApiResult<ExamResultDto>>
    {
        private readonly IExamResultRepository _examResultRepository;
        private readonly IExamRepository _examRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public StartExamCommandHandler(
          IExamResultRepository examResultRepository,
          IExamRepository examRepository,
          IHttpContextAccessor httpContextAccessor,
          IMapper mapper)
        {
            _examResultRepository = examResultRepository;
            _httpContextAccessor = httpContextAccessor;
            _examRepository = examRepository;
            _mapper = mapper;
        }
        public async Task<ApiResult<ExamResultDto>> Handle(StartExamCommand request, CancellationToken cancellationToken)
        {
            var exam = await _examRepository.GetExamByIdAsync(request.ExamId);
            var examResult = new ExamResult(_httpContextAccessor.GetUserId(), request.ExamId);
            examResult.ExamStartDate = DateTime.UtcNow;
            examResult.ExamTitle = exam.Name;
            if (exam.IsTimeRestricted)
            {
                var durations = exam.Duration.Split(":");
                var durationTimeSpan = new TimeSpan(0, int.Parse(durations[0]), int.Parse(durations[1]));
                examResult.ExamFinishDate = DateTime.UtcNow.Add(durationTimeSpan);
            }

            examResult.CorrectQuestionCount = 0;
            examResult.QuestionResults = exam.Questions
                    .Select(x => new QuestionResult(x.Id,
                    x.Content,
                    x.QuestionType,
                    x.Level,
                    x.Answers.Select(a => new AnswerResult(a.Id, a.Content, null, a.IsCorrect)).ToList(),
                    x.Explain,
                    null))
                .ToList(); ;
            examResult.Finished = false;

            await _examResultRepository.InsertAsync(examResult);
            var dto = _mapper.Map<ExamResultDto>(examResult);
            return new ApiSuccessResult<ExamResultDto>(200, dto);
        }
    }
}