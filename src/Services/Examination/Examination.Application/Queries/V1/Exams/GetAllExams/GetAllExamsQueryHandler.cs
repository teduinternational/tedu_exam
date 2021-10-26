using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Examination.Application.Queries.V1.Exams.GetAllExams;
using Examination.Domain.AggregateModels.ExamAggregate;
using Examination.Shared.Exams;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Examination.Application.Queries.V1.Exams.GetHomeExamList
{
    public class GetAllExamsQueryHandler : IRequestHandler<GetAllExamsQuery, ApiResult<IEnumerable<ExamDto>>>
    {
        private readonly IExamRepository _examRepository;
        private readonly IClientSessionHandle _clientSessionHandle;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllExamsQueryHandler> _logger;

        public GetAllExamsQueryHandler(
                IExamRepository examRepository,
                IMapper mapper,
                ILogger<GetAllExamsQueryHandler> logger,
                IClientSessionHandle clientSessionHandle
            )
        {
            _examRepository = examRepository ?? throw new ArgumentNullException(nameof(examRepository));
            _clientSessionHandle = clientSessionHandle ?? throw new ArgumentNullException(nameof(_clientSessionHandle));
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<ApiResult<IEnumerable<ExamDto>>> Handle(GetAllExamsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("BEGIN: GetHomeExamListQueryHandler");

            var exams = await _examRepository.GetAllExamsAsync();
            var examDtos = _mapper.Map<IEnumerable<ExamDto>>(exams);

            _logger.LogInformation("END: GetHomeExamListQueryHandler");
            return new ApiSuccessResult<IEnumerable<ExamDto>>(200, examDtos);
        }
    }
}