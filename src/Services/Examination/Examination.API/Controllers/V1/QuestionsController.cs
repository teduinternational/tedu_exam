using Examination.Application.Commands.V1.Questions.CreateQuestion;
using Examination.Application.Commands.V1.Questions.DeleteQuestion;
using Examination.Application.Commands.V1.Questions.UpdateQuestion;
using Examination.Application.Queries.V1.Questions.GetQuestionById;
using Examination.Application.Queries.V1.Questions.GetQuestionsPaging;
using Examination.Dtos.SeedWork;
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

        [HttpGet]
        [ProducesResponseType(typeof(PagedList<QuestionDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetQuestionsPagingAsync([FromQuery] GetQuestionsPagingQuery query)
        {
            _logger.LogInformation("BEGIN: GetQuestionsPagingAsync");

            var queryResult = await _mediator.Send(query);

            _logger.LogInformation("END: GetQuestionsPagingAsync");

            return Ok(queryResult);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(QuestionDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetQuestionsByIdAsync(string id)
        {
            _logger.LogInformation("BEGIN: GetQuestionsByIdAsync");

            var queryResult = await _mediator.Send(new GetQuestionByIdQuery(id));

            _logger.LogInformation("END: GetQuestionsByIdAsync");
            return Ok(queryResult);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateQuestionAsync([FromBody] UpdateQuestionRequest request)
        {
            _logger.LogInformation("BEGIN: UpdateQuestionAsync");
            var queryResult = await _mediator.Send(new UpdateQuestionCommand()
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
            return Ok(queryResult);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateQuestionAsync([FromBody] CreateQuestionRequest request)
        {
            _logger.LogInformation("BEGIN: CreateQuestionAsync");

            var queryResult = await _mediator.Send(new CreateQuestionCommand()
            {
                Content = request.Content,
                QuestionType = request.QuestionType,
                Level = request.Level,
                CategoryId = request.CategoryId,
                Answers = request.Answers,
                Explain = request.Explain
            });
            if (queryResult == null)
                return BadRequest();

            _logger.LogInformation("END: CreateQuestionAsync");
            return Ok(queryResult);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteQuestionAsync(string id)
        {
            _logger.LogInformation("BEGIN: GetExamList");

            var queryResult = await _mediator.Send(new DeleteQuestionCommand(id));

            _logger.LogInformation("END: GetExamList");
            return Ok(queryResult);
        }
    }
}
