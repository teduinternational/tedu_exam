using Examination.Application.Queries.V1.Categories.GetCategoryList;
using Examination.Dtos.Categories;
using Examination.Dtos.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> GetCategories([FromQuery] GetCategoryListPagingQuery query)
        {
            _logger.LogInformation("BEGIN: GetExamList");

            var queryResult = await _mediator.Send(query);

            _logger.LogInformation("END: GetExamList");
            return Ok(queryResult);
        }
    }
}
