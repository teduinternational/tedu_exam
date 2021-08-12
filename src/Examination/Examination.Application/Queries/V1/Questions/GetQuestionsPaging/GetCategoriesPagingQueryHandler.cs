using AutoMapper;
using Examination.Domain.AggregateModels.QuestionAggregate;
using Examination.Dtos.Questions;
using Examination.Dtos.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Examination.Application.Queries.V1.Questions.GetQuestionsPaging
{
    public class GetQuestionsPagingQueryHandler : IRequestHandler<GetQuestionsPagingQuery, PagedList<QuestionDto>>
    {

        private readonly IQuestionRepository _questionRepository;
        private readonly IClientSessionHandle _clientSessionHandle;
        private readonly IMapper _mapper;
        private readonly ILogger<GetQuestionsPagingQueryHandler> _logger;

        public GetQuestionsPagingQueryHandler(
                IQuestionRepository QuestionRepository,
                IMapper mapper,
                ILogger<GetQuestionsPagingQueryHandler> logger,
                IClientSessionHandle clientSessionHandle
            )
        {
            _questionRepository = QuestionRepository ?? throw new ArgumentNullException(nameof(QuestionRepository));
            _clientSessionHandle = clientSessionHandle ?? throw new ArgumentNullException(nameof(_clientSessionHandle));
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<PagedList<QuestionDto>> Handle(GetQuestionsPagingQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("BEGIN: GetHomeExamListQueryHandler");

            var result = await _questionRepository.GetQuestionsPagingAsync(request.SearchKeyword, request.PageIndex, request.PageSize);
            var items = _mapper.Map<List<QuestionDto>>(result.Item1);

            _logger.LogInformation("END: GetHomeExamListQueryHandler");
            return new PagedList<QuestionDto>(items, result.Item2, request.PageIndex, request.PageSize);
        }
    }
}
