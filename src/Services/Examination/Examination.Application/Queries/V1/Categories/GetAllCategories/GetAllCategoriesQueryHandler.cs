using AutoMapper;
using Examination.Application.Queries.V1.Categories.GetAllCategories;
using Examination.Domain.AggregateModels.CategoryAggregate;
using Examination.Dtos.SeedWork;
using Examination.Shared.Categories;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examination.Application.Queries.V1.Categories.GetCategoriesPaging
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, ApiResult<List<CategoryDto>>>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCategoriesPagingQueryHandler> _logger;

        public GetAllCategoriesQueryHandler(
                ICategoryRepository categoryRepository,
                IMapper mapper,
                ILogger<GetCategoriesPagingQueryHandler> logger
            )
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<ApiResult<List<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("BEGIN: GetHomeExamListQueryHandler");

            var result = await _categoryRepository.GetAllCategoriesAsync();
            var items = _mapper.Map<List<CategoryDto>>(result);

            _logger.LogInformation("END: GetHomeExamListQueryHandler");
            return new ApiSuccessResult<List<CategoryDto>>(items);
        }
    }
}
