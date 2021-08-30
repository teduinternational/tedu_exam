using Examination.Dtos.Categories;
using Examination.Dtos.SeedWork;
using Examination.Shared.Questions;
using MediatR;

namespace Examination.Application.Queries.V1.Questions.GetQuestionsPaging
{
    public class GetQuestionsPagingQuery : IRequest<PagedList<QuestionDto>>
    {
        public string CategoryId { get; set; }
        public string SearchKeyword { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
