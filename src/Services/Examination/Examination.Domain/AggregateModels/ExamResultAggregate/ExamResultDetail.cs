using System.Collections.Generic;
using System.Linq;
using Examination.Domain.AggregateModels.QuestionAggregate;
using Examination.Domain.SeedWork;
using MongoDB.Bson.Serialization.Attributes;

namespace Examination.Domain.AggregateModels.ExamResultAggregate
{
    public class ExamResultDetail : Entity
    {
        public ExamResultDetail(Question question, IEnumerable<Answer> selectedAnswers, string explain)
        {
            (Question, SelectedAnswers) = (question, selectedAnswers);
            IsCorrect = this.SelectedAnswers.Select(x => x.Id).Except(question.Answers.Select(x => x.Id)).ToList().Count == 0;
        }

        [BsonElement("question")]
        public Question Question { get; set; }
        [BsonElement("selectedAnswers")]
        public IEnumerable<Answer> SelectedAnswers { get; set; }
        [BsonElement("isCorrect")]
        public bool IsCorrect { get; set; }
    }
}