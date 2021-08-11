using AutoMapper;
using Examination.Domain.AggregateModels.CategoryAggregate;
using Examination.Dtos.Categories;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examination.Application.Commands.V1.Categories.UpdateCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<DeleteCategoryCommandHandler> _logger;

        public DeleteCategoryCommandHandler(
                ICategoryRepository categoryRepository,
                ILogger<DeleteCategoryCommandHandler> logger
            )
        {
            _categoryRepository = categoryRepository;
            _logger = logger;

        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _categoryRepository.GetCategoriesByIdAsync(request.Id);
            if (itemToUpdate == null)
            {
                _logger.LogError($"Item is not found {request.Id}");
                return false;
            }

            try
            {
                await _categoryRepository.DeleteAsync(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
