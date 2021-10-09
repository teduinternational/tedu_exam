using Examination.Application.Queries.V1.ExamResults.GetExamResultById;
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
    }
}
