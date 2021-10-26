using Examination.Domain.SeedWork;
using MongoDB.Bson.Serialization.Attributes;

namespace Examination.Domain.AggregateModels.ExamResultAggregate
{
    public class AnswerResult : Entity
    {
        public AnswerResult() { }
        public AnswerResult(string id, string content, bool? userChosen, bool isCorrect)
        {
            Id = id;
            UserChosen = userChosen;
            Content = content;
            IsCorrect = isCorrect;
        }

        [BsonElement("content")]
        public string Content { get; set; }

        [BsonElement("userChosen")]
        public bool? UserChosen { get; set; }

        [BsonElement("isCorrect")]
        public bool IsCorrect { get; set; }
    }
}