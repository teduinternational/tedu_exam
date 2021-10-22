using Examination.Application.Commands.V1.Exams.FinishExam;
using Examination.Application.Commands.V1.Exams.SkipExam;
using Examination.Application.Commands.V1.Exams.StartExam;
using Examination.Application.Commands.V1.Exams.SubmitQuestion;
using Examination.Application.Queries.V1.ExamResults.GetExamResultById;
using Examination.Application.Queries.V1.ExamResults.GetExamResultsByUserIdPaging;
using Examination.Application.Queries.V1.ExamResults.GetExamResultsPaging;
using Examination.Shared.ExamResults;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Examination.API.Controllers.V1
{
    public class ExamResultsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ExamResultsController> _logger;

        public ExamResultsController(IMediator mediator, ILogger<ExamResultsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiSuccessResult<ExamResultDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetExamResultByIdAsync(string id)
        {
            _logger.LogInformation("BEGIN: GetExamResultByIdAsync");

            var result = await _mediator.Send(new GetExamResultByIdQuery(id));

            _logger.LogInformation("END: GetExamResultByIdAsync");
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("finish")]
        [ProducesResponseType(typeof(ApiSuccessResult<ExamResultDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> FinishExamAsync(FinishExamRequest request)
        {
            _logger.LogInformation("BEGIN: FinishExamAsync");

            var result = await _mediator.Send(new FinishExamCommand() { ExamResultId = request.ExamResultId });

            _logger.LogInformation("END: FinishExamAsync");
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("skip")]
        [ProducesResponseType(typeof(ApiSuccessResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SkipExamAsync(SkipExamRequest request)
        {
            _logger.LogInformation("BEGIN: SkipExamAsync");

            var result = await _mediator.Send(new SkipExamCommand() { ExamResultId = request.ExamResultId });

            _logger.LogInformation("END: SkipExamAsync");
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("next-question")]
        [ProducesResponseType(typeof(ApiSuccessResult<ExamResultDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> NextQuestionAsync(NextQuestionRequest request)
        {
            _logger.LogInformation("BEGIN: NextQuestionAsync");

            var result = await _mediator.Send(new SubmitQuestionCommand()
            {
                ExamResultId = request.ExamResultId,
                QuestionId = request.QuestionId,
                AnswerIds = request.AnswerIds
            });

            _logger.LogInformation("END: NextQuestionAsync");
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("start")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> StartExamAsync([FromBody] StartExamRequest request)
        {
            _logger.LogInformation("BEGIN: StartExamAsync");
            var result = await _mediator.Send(new StartExamCommand()
            {
                ExamId = request.ExamId
            });

            _logger.LogInformation("END: StartExamAsync");
            return StatusCode(result.StatusCode, result);
        }

        //api/v1/examResults/user/{id}
        [HttpGet("user")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetExamResultsByUserIdPagingAsync([FromQuery] GetExamResultsByUserIdPagingQuery request)
        {
            _logger.LogInformation("BEGIN: GetExamResultsByUserIdPagingAsync");
            var result = await _mediator.Send(request);

            _logger.LogInformation("END: GetExamResultsByUserIdPagingAsync");
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("paging")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetExamResultsPagingAsync([FromQuery] GetExamResultsPagingQuery request)
        {
            _logger.LogInformation("BEGIN: GetExamResultsPagingAsync");
            var result = await _mediator.Send(request);

            _logger.LogInformation("END: GetExamResultsPagingAsync");
            return StatusCode(result.StatusCode, result);
        }
    }
}