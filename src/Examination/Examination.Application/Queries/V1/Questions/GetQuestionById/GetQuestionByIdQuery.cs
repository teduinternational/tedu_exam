﻿using Examination.Dtos.Questions;
using MediatR;

namespace Examination.Application.Queries.V1.Questions.GetQuestionById
{
    public class GetQuestionByIdQuery : IRequest<QuestionDto>
    {
        public GetQuestionByIdQuery(string id)
        {
            Id = id;
        }
        public string Id { set; get; }
    }
}
