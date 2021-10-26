using Examination.Shared.Categories;
using Examination.Shared.Questions;
using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Queries.V1.Questions.GetQuestionById
{
    public class GetQuestionByIdQuery : IRequest<ApiResult<QuestionDto>>
    {
        public GetQuestionByIdQuery(string id)
        {
            Id = id;
        }
        public string Id { set; get; }
    }
}
