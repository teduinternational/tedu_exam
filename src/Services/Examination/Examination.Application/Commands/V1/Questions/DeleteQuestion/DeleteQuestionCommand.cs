using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Commands.V1.Questions.DeleteQuestion
{
    public class DeleteQuestionCommand : IRequest<ApiResult<bool>>
    {
        public DeleteQuestionCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
