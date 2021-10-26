using Examination.Domain.AggregateModels.CategoryAggregate;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Examination.Application.Commands.V1.Categories.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ApiResult<bool>>
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

        public async Task<ApiResult<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _categoryRepository.GetCategoriesByIdAsync(request.Id);
            if (itemToUpdate == null)
            {
                _logger.LogError($"Item is not found {request.Id}");
                return new ApiErrorResult<bool>(400, "Item is not found {request.Id}");
            }

            try
            {
                await _categoryRepository.DeleteAsync(request.Id);
                return new ApiSuccessResult<bool>(200, true, "Delete successful");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
