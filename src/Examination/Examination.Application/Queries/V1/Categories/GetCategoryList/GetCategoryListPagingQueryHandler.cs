﻿using AutoMapper;
using Examination.Domain.AggregateModels.CategoryAggregate;
using Examination.Dtos.Categories;
using Examination.Dtos.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Examination.Application.Queries.V1.Categories.GetCategoryList
{
    public class GetCategoryListPagingQueryHandler : IRequestHandler<GetCategoryListPagingQuery, PagedList<CategoryDto>>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IClientSessionHandle _clientSessionHandle;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCategoryListPagingQueryHandler> _logger;

        public GetCategoryListPagingQueryHandler(
                ICategoryRepository categoryRepository,
                IMapper mapper,
                ILogger<GetCategoryListPagingQueryHandler> logger,
                IClientSessionHandle clientSessionHandle
            )
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _clientSessionHandle = clientSessionHandle ?? throw new ArgumentNullException(nameof(_clientSessionHandle));
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<PagedList<CategoryDto>> Handle(GetCategoryListPagingQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("BEGIN: GetHomeExamListQueryHandler");

            var result = await _categoryRepository.GetCategoryListPaging(request.SearchKeyword, request.PageIndex, request.PageSize);
            var items = _mapper.Map<List<CategoryDto>>(result.Item1);

            _logger.LogInformation("END: GetHomeExamListQueryHandler");
            return new PagedList<CategoryDto>()
            {
                Items = items,
                MetaData = new MetaData()
                {
                    CurrentPage = request.PageIndex,
                    PageSize = request.PageSize,
                    TotalCount = result.Item2,
                }
            };
        }
    }
}
