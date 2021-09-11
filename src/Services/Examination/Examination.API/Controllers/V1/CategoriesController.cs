using Examination.Application.Commands.V1.Categories.CreateCategory;
using Examination.Application.Commands.V1.Categories.DeleteCategory;
using Examination.Application.Commands.V1.Categories.UpdateCategory;
using Examination.Application.Queries.V1.Categories.GetAllCategories;
using Examination.Application.Queries.V1.Categories.GetCategoriesPaging;
using Examination.Application.Queries.V1.Categories.GetCategoryById;
using Examination.Shared.Categories;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Examination.API.Controllers.V1
{
    public class CategoriesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(IMediator mediator, ILogger<CategoriesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("paging")]
        [ProducesResponseType(typeof(ApiSuccessResult<PagedList<CategoryDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCategoriesPagingAsync([FromQuery] GetCategoriesPagingQuery query)
        {
            _logger.LogInformation("BEGIN: GetCategoriesPagingAsync");

            var result = await _mediator.Send(query);

            _logger.LogInformation("END: GetCategoriesPagingAsync");

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiSuccessResult<CategoryDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetCategoriesByIdAsync(string id)
        {
            _logger.LogInformation("BEGIN: GetCategoriesByIdAsync");

            var result = await _mediator.Send(new GetCategoryByIdQuery(id));

            _logger.LogInformation("END: GetCategoriesByIdAsync");
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] UpdateCategoryRequest request)
        {
            _logger.LogInformation("BEGIN: UpdateCategoryAsync");

            var result = await _mediator.Send(new UpdateCategoryCommand()
            {
                Id = request.Id,
                Name = request.Name,
                UrlPath = request.UrlPath
            });

            _logger.LogInformation("END: UpdateCategoryAsync");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryRequest request)
        {
            _logger.LogInformation("BEGIN: CreateCategoryAsync");

            var result = await _mediator.Send(new CreateCategoryCommand()
            {
                Name = request.Name,
                UrlPath = request.UrlPath
            });
            if (result == null)
                return BadRequest(result);

            _logger.LogInformation("END: CreateCategoryAsync");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteCategoryAsync(string id)
        {
            _logger.LogInformation("BEGIN: DeleteCategoryAsync");

            var result = await _mediator.Send(new DeleteCategoryCommand(id));

            _logger.LogInformation("END: DeleteCategoryAsync");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiSuccessResult<List<CategoryDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            _logger.LogInformation("BEGIN: GetAllCategoriesAsync");

            var result = await _mediator.Send(new GetAllCategoriesQuery());

            _logger.LogInformation("END: GetAllCategoriesAsync");

            return Ok(result);
        }
    }
}
