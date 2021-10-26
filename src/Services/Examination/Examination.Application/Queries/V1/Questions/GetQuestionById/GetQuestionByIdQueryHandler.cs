using AutoMapper;
using Examination.Domain.AggregateModels.QuestionAggregate;
using Examination.Shared.Questions;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Examination.Application.Queries.V1.Questions.GetQuestionById
{
    public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, ApiResult<QuestionDto>>
    {

        private readonly IQuestionRepository _questionRepository;
        private readonly IClientSessionHandle _clientSessionHandle;
        private readonly IMapper _mapper;
        private readonly ILogger<GetQuestionByIdQueryHandler> _logger;

        public GetQuestionByIdQueryHandler(
                IQuestionRepository questionRepository,
                IMapper mapper,
                ILogger<GetQuestionByIdQueryHandler> logger,
                IClientSessionHandle clientSessionHandle
            )
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
            _clientSessionHandle = clientSessionHandle ?? throw new ArgumentNullException(nameof(_clientSessionHandle));
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<ApiResult<QuestionDto>> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("BEGIN: GetQuestionByIdQueryHandler");

            var result = await _questionRepository.GetQuestionsByIdAsync(request.Id);
            var item = _mapper.Map<QuestionDto>(result);

            _logger.LogInformation("END: GetQuestionByIdQueryHandler");

            return new ApiSuccessResult<QuestionDto>(200, item);
        }
    }
}
