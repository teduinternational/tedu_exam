using AutoMapper;
using Examination.Domain.AggregateModels.ExamAggregate;
using Examination.Shared.SeedWork;
using Examination.Shared.Exams;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Examination.Application.Queries.V1.Exams.GetExamsPaging
{
    public class GetExamsPagingQueryHandler : IRequestHandler<GetExamsPagingQuery, ApiResult<PagedList<ExamDto>>>
    {

        private readonly IExamRepository _examRepository;
        private readonly IClientSessionHandle _clientSessionHandle;
        private readonly IMapper _mapper;
        private readonly ILogger<GetExamsPagingQueryHandler> _logger;

        public GetExamsPagingQueryHandler(
                IExamRepository examRepository,
                IMapper mapper,
                ILogger<GetExamsPagingQueryHandler> logger,
                IClientSessionHandle clientSessionHandle
            )
        {
            _examRepository = examRepository ?? throw new ArgumentNullException(nameof(examRepository));
            _clientSessionHandle = clientSessionHandle ?? throw new ArgumentNullException(nameof(_clientSessionHandle));
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<ApiResult<PagedList<ExamDto>>> Handle(GetExamsPagingQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("BEGIN: GetExamsPagingQueryHandler");

            var result = await _examRepository.GetExamsPagingAsync(request.CategoryId,
                request.SearchKeyword,
                request.PageIndex,
                request.PageSize);

            var items = _mapper.Map<List<ExamDto>>(result.Items);

            _logger.LogInformation("END: GetExamsPagingQueryHandler");
            var pagedItems = new PagedList<ExamDto>(items, result.MetaData.TotalCount, request.PageIndex, request.PageSize);

            return new ApiSuccessResult<PagedList<ExamDto>>(200, pagedItems);
        }
    }
}