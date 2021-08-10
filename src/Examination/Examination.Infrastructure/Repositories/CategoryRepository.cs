﻿using Examination.Domain.AggregateModels.CategoryAggregate;
using Examination.Infrastructure.SeedWork;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(
          IMongoClient mongoClient,
          IClientSessionHandle clientSessionHandle,
          IOptions<ExamSettings> settings,
          IMediator mediator)
      : base(mongoClient, clientSessionHandle, settings, mediator, Constants.Collections.Exam)
        {
        }

        public async Task<Tuple<List<Category>, long>> GetCategoryListPaging(string searchKeyword, int pageIndex, int pageSize)
        {
            FilterDefinition<Category> filter = Builders<Category>.Filter.Empty;
            if (!string.IsNullOrEmpty(searchKeyword))
                filter = Builders<Category>.Filter.Eq(s => s.Name, searchKeyword);

            var totalRow = await Collection.Find(filter).CountDocumentsAsync();
            var items = await Collection.Find(filter)
                .Skip((pageIndex - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();

            return new Tuple<List<Category>, long>(items, totalRow);
        }
    }
}
