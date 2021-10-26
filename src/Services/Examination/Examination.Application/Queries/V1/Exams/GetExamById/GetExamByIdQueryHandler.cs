using AutoMapper;
using Examination.Domain.AggregateModels.ExamAggregate;
using Examination.Shared.Exams;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Examination.Application.Queries.V1.Exams.GetExamById
{
    public class GetExamByIdQueryHandler : IRequestHandler<GetExamByIdQuery, ApiResult<ExamDto>>
    {

        private readonly IExamRepository _examRepository;
        private readonly IClientSessionHandle _clientSessionHandle;
        private readonly IMapper _mapper;
        private readonly ILogger<GetExamByIdQueryHandler> _logger;

        public GetExamByIdQueryHandler(
                IExamRepository examRepository,
                IMapper mapper,
                ILogger<GetExamByIdQueryHandler> logger,
                IClientSessionHandle clientSessionHandle
            )
        {
            _examRepository = examRepository ?? throw new ArgumentNullException(nameof(examRepository));
            _clientSessionHandle = clientSessionHandle ?? throw new ArgumentNullException(nameof(_clientSessionHandle));
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<ApiResult<ExamDto>> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("BEGIN: GetExamByIdQueryHandler");

            var result = await _examRepository.GetExamByIdAsync(request.Id);
            var item = _mapper.Map<ExamDto>(result);

            _logger.LogInformation("END: GetExamByIdQueryHandler");

            return new ApiSuccessResult<ExamDto>(200, item);
        }
    }
}