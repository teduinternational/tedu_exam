using System.Net;
using System.Threading.Tasks;
using Examination.Application.Commands.V1.Exams.CreateExam;
using Examination.Application.Commands.V1.Exams.DeleteExam;
using Examination.Application.Commands.V1.Exams.UpdateExam;
using Examination.Application.Queries.V1.Exams.GetExamById;
using Examination.Application.Queries.V1.Exams.GetExamsPaging;
using Examination.Application.Queries.V1.Exams.GetAllExams;
using Examination.Shared.Exams;
using Examination.Shared.Questions;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Examination.API.Controllers.V1
{

    public class ExamsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ExamsController> _logger;

        public ExamsController(IMediator mediator, ILogger<ExamsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExams()
        {
            _logger.LogInformation("BEGIN: GetAllExams");

            var result = await _mediator.Send(new GetAllExamsQuery());

            _logger.LogInformation("END: GetAllExams");
            return StatusCode(result.StatusCode, result);
        }
        [HttpGet("paging")]
        [ProducesResponseType(typeof(ApiSuccessResult<PagedList<ExamDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetExamsPagingAsync([FromQuery] GetExamsPagingQuery query)
        {
            _logger.LogInformation("BEGIN: GetExamsPagingAsync");

            var result = await _mediator.Send(query);

            _logger.LogInformation("END: GetExamsPagingAsync");

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiSuccessResult<ExamDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetExamByIdAsync(string id)
        {
            _logger.LogInformation("BEGIN: GetExamByIdAsync");

            var result = await _mediator.Send(new GetExamByIdQuery(id));

            _logger.LogInformation("END: GetExamByIdAsync");
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateExamAsync([FromBody] UpdateExamRequest request)
        {
            _logger.LogInformation("BEGIN: UpdateExamAsync");
            var result = await _mediator.Send(new UpdateExamCommand()
            {
                Id = request.Id,
                Name = request.Name,
                AutoGenerateQuestion = request.AutoGenerateQuestion,
                CategoryId = request.CategoryId,
                Content = request.Content,
                Duration = request.Duration,
                IsTimeRestricted = request.IsTimeRestricted,
                Level = request.Level,
                NumberOfQuestionCorrectForPass = request.NumberOfQuestionCorrectForPass,
                NumberOfQuestions = request.NumberOfQuestions,
                Questions = request.Questions,
                ShortDesc = request.ShortDesc
            });

            _logger.LogInformation("END: UpdateExamAsync");
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateExamAsync([FromBody] CreateExamRequest request)
        {
            _logger.LogInformation("BEGIN: CreateExamAsync");

            var result = await _mediator.Send(new CreateExamCommand()
            {
                Name = request.Name,
                AutoGenerateQuestion = request.AutoGenerateQuestion,
                CategoryId = request.CategoryId,
                Content = request.Content,
                Duration = request.Duration,
                IsTimeRestricted = request.IsTimeRestricted,
                Level = request.Level,
                NumberOfQuestionCorrectForPass = request.NumberOfQuestionCorrectForPass,
                NumberOfQuestions = request.NumberOfQuestions,
                Questions = request.Questions,
                ShortDesc = request.ShortDesc
            });
            _logger.LogInformation("END: CreateExamAsync");
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteExamAsync(string id)
        {
            _logger.LogInformation("BEGIN: DeleteExamAsync");

            var result = await _mediator.Send(new DeleteExamCommand(id));

            _logger.LogInformation("END: DeleteExamAsync");
            return StatusCode(result.StatusCode, result);
        }
    }
}