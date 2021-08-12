using Examination.Dtos.Categories;
using Examination.Dtos.Questions;
using MediatR;

namespace Examination.Application.Commands.V1.Questions.CreateQuestion
{
    public class CreateQuestionCommand : IRequest<QuestionDto>
    {
        public string Name { set; get; }
        public string UrlPath { get; set; }
    }
}
