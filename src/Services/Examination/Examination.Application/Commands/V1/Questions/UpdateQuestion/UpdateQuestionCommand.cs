using Examination.Shared.Enums;
using Examination.Shared.Questions;
using MediatR;
using System.Collections.Generic;

namespace Examination.Application.Commands.V1.Questions.UpdateQuestion
{
    public class UpdateQuestionCommand : IRequest<bool>
    {
        public string Id { get; set; }

        public string Content { get; set; }


        public QuestionType QuestionType { get; set; }


        public Level Level { set; get; }


        public string CategoryId { get; set; }


        public List<AnswerDto> Answers { set; get; } = new List<AnswerDto>();

        public string Explain { get; set; }
    }
}
