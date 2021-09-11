using System.Threading.Tasks;
using Examination.Application.Queries.V1.Exams.GetHomeExamList;
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
        public async Task<IActionResult> GetExamList()
        {
            _logger.LogInformation("BEGIN: GetExamList");

            var result = await _mediator.Send(new GetHomeExamListQuery());

            _logger.LogInformation("END: GetExamList");
            return Ok(result);
        }

    }
}