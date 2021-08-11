using Examination.Dtos.Categories;
using MediatR;

namespace Examination.Application.Commands.V1.Categories.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public string Name { set; get; }
        public string UrlPath { get; set; }
    }
}
