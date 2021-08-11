using Examination.Application.Commands.V1.Categories.CreateCategory;
using Examination.Application.Commands.V1.Categories.DeleteCategory;
using Examination.Application.Commands.V1.Categories.UpdateCategory;
using Examination.Application.Queries.V1.Categories.GetCategoriesPaging;
using Examination.Application.Queries.V1.Categories.GetCategoryById;
using Examination.Dtos.Categories;
using Examination.Dtos.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Examination.API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(IMediator mediator, ILogger<CategoriesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedList<CategoryDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCategoriesPagingAsync([FromQuery] GetCategoriesPagingQuery query)
        {
            _logger.LogInformation("BEGIN: GetCategoriesPagingAsync");

            var queryResult = await _mediator.Send(query);

            _logger.LogInformation("END: GetCategoriesPagingAsync");

            return Ok(queryResult);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoryDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetCategoriesByIdAsync(string id)
        {
            _logger.LogInformation("BEGIN: GetCategoriesByIdAsync");

            var queryResult = await _mediator.Send(new GetCategoryByIdQuery(id));

            _logger.LogInformation("END: GetCategoriesByIdAsync");
            return Ok(queryResult);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] UpdateCategoryRequest request)
        {
            _logger.LogInformation("BEGIN: UpdateCategoryAsync");

            var queryResult = await _mediator.Send(new UpdateCategoryCommand()
            {
                Id = request.Id,
                Name = request.Name,
                UrlPath = request.UrlPath
            });

            _logger.LogInformation("END: UpdateCategoryAsync");
            return Ok(queryResult);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryRequest request)
        {
            _logger.LogInformation("BEGIN: CreateCategoryAsync");

            var queryResult = await _mediator.Send(new CreateCategoryCommand()
            {
                Name = request.Name,
                UrlPath = request.UrlPath
            });
            if (queryResult == null)
                return BadRequest();

            _logger.LogInformation("END: CreateCategoryAsync");
            return Ok(queryResult);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteCategoryAsync(string id)
        {
            _logger.LogInformation("BEGIN: GetExamList");

            var queryResult = await _mediator.Send(new DeleteCategoryCommand(id));

            _logger.LogInformation("END: GetExamList");
            return Ok(queryResult);
        }
    }
}
