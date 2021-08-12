using MediatR;

namespace Examination.Application.Commands.V1.Categories.UpdateQuestion
{
    public class UpdateQuestionCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string Name { set; get; }
        public string UrlPath { get; set; }
    }
}
