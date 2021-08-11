﻿using MediatR;

namespace Examination.Application.Commands.V1.Categories.UpdateCategory
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public DeleteCategoryCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
