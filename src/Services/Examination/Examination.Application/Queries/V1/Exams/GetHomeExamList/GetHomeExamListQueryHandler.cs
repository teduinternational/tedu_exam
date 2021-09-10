using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Examination.Domain.AggregateModels.ExamAggregate;
using Examination.Dtos.Exams;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Examination.Application.Queries.V1.Exams.GetHomeExamList
{
    public class GetHomeExamListQueryHandler : IRequestHandler<GetHomeExamListQuery, ApiResult<IEnumerable<ExamDto>>>
    {
        private readonly IExamRepository _examRepository;
        private readonly IClientSessionHandle _clientSessionHandle;
        private readonly IMapper _mapper;
        private readonly ILogger<GetHomeExamListQueryHandler> _logger;

        public GetHomeExamListQueryHandler(
                IExamRepository examRepository,
                IMapper mapper,
                ILogger<GetHomeExamListQueryHandler> logger,
                IClientSessionHandle clientSessionHandle
            )
        {
            _examRepository = examRepository ?? throw new ArgumentNullException(nameof(examRepository));
            _clientSessionHandle = clientSessionHandle ?? throw new ArgumentNullException(nameof(_clientSessionHandle));
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<ApiResult<IEnumerable<ExamDto>>> Handle(GetHomeExamListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("BEGIN: GetHomeExamListQueryHandler");

            var exams = await _examRepository.GetExamListAsync();
            var examDtos = _mapper.Map<IEnumerable<ExamDto>>(exams);

            _logger.LogInformation("END: GetHomeExamListQueryHandler");
            return new ApiSuccessResult<IEnumerable<ExamDto>>(examDtos);
        }
    }
}