using System.Threading.Tasks;
using Examination.Application.Queries.GetHomeExamList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Examination.API.Controllers.V1
{

    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ExamsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExamsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetExamList()
        {
            var query = new GetHomeExamListQuery();
            var queryResult = await _mediator.Send(query);
            return Ok(queryResult);
        }

    }
}