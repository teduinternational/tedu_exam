﻿using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Commands.V1.Categories.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<ApiResult<bool>>
    {
        public DeleteCategoryCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
