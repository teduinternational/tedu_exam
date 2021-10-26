using Examination.Shared.Categories;
using Examination.Shared.Exams;
using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Queries.V1.Exams.GetExamById
{
    public class GetExamByIdQuery : IRequest<ApiResult<ExamDto>>
    {
        public GetExamByIdQuery(string id)
        {
            Id = id;
        }
        public string Id { set; get; }
    }
}