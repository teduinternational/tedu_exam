using Examination.Application.Commands.V1.Questions.CreateQuestion;
using Examination.Application.Commands.V1.Questions.DeleteQuestion;
using Examination.Application.Commands.V1.Questions.UpdateQuestion;
using Examination.Application.Queries.V1.Questions.GetQuestionById;
using Examination.Application.Queries.V1.Questions.GetQuestionsPaging;
using Examination.Shared.SeedWork;
using Examination.Shared.Questions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Examination.API.Controllers.V1
{
    public class QuestionsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<QuestionsController> _logger;

        public QuestionsController(IMediator mediator, ILogger<QuestionsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("paging")]
        [ProducesResponseType(typeof(ApiSuccessResult<PagedList<QuestionDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetQuestionsPagingAsync([FromQuery] GetQuestionsPagingQuery query)
        {
            _logger.LogInformation("BEGIN: GetQuestionsPagingAsync");

            var result = await _mediator.Send(query);

            _logger.LogInformation("END: GetQuestionsPagingAsync");

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiSuccessResult<QuestionDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetQuestionsByIdAsync(string id)
        {
            _logger.LogInformation("BEGIN: GetQuestionsByIdAsync");

            var result = await _mediator.Send(new GetQuestionByIdQuery(id));

            _logger.LogInformation("END: GetQuestionsByIdAsync");
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateQuestionAsync([FromBody] UpdateQuestionRequest request)
        {
            _logger.LogInformation("BEGIN: UpdateQuestionAsync");
            var result = await _mediator.Send(new UpdateQuestionCommand()
            {
                Id = request.Id,
                Content = request.Content,
                QuestionType = request.QuestionType,
                Level = request.Level,
                CategoryId = request.CategoryId,
                Answers = request.Answers,
                Explain = request.Explain
            });

            _logger.LogInformation("END: UpdateQuestionAsync");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateQuestionAsync([FromBody] CreateQuestionRequest request)
        {
            _logger.LogInformation("BEGIN: CreateQuestionAsync");

            var result = await _mediator.Send(new CreateQuestionCommand()
            {
                Content = request.Content,
                QuestionType = request.QuestionType,
                Level = request.Level,
                CategoryId = request.CategoryId,
                Answers = request.Answers,
                Explain = request.Explain
            });
            if (result == null)
                return BadRequest(result);

            _logger.LogInformation("END: CreateQuestionAsync");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteQuestionAsync(string id)
        {
            _logger.LogInformation("BEGIN: DeleteQuestionAsync");

            var result = await _mediator.Send(new DeleteQuestionCommand(id));

            _logger.LogInformation("END: DeleteQuestionAsync");
            return Ok(result);
        }
    }
}
