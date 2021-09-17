﻿using AutoMapper;
using Examination.Domain.AggregateModels.CategoryAggregate;
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
    public class GetCategoriesPagingQueryHandler : IRequestHandler<GetCategoriesPagingQuery,ApiResult<PagedList<CategoryDto>>>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IClientSessionHandle _clientSessionHandle;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCategoriesPagingQueryHandler> _logger;

        public GetCategoriesPagingQueryHandler(
                ICategoryRepository categoryRepository,
                IMapper mapper,
                ILogger<GetCategoriesPagingQueryHandler> logger,
                IClientSessionHandle clientSessionHandle
            )
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _clientSessionHandle = clientSessionHandle ?? throw new ArgumentNullException(nameof(_clientSessionHandle));
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<ApiResult<PagedList<CategoryDto>>> Handle(GetCategoriesPagingQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("BEGIN: GetHomeExamListQueryHandler");

            var result = await _categoryRepository.GetCategoriesPagingAsync(request.SearchKeyword, request.PageIndex, request.PageSize);
            var items = _mapper.Map<List<CategoryDto>>(result.Items);

            _logger.LogInformation("END: GetHomeExamListQueryHandler");
            var pagedResult = new PagedList<CategoryDto>(items, result.MetaData.TotalCount, request.PageIndex, request.PageSize);
            return new ApiSuccessResult<PagedList<CategoryDto>>(200, pagedResult);
        }
    }
}
