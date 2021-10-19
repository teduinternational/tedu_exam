using Examination.Domain.SeedWork;
using MongoDB.Bson.Serialization.Attributes;

namespace Examination.Domain.AggregateModels.ExamResultAggregate
{
    public class AnswerResult : Entity
    {
        public AnswerResult() { }
        public AnswerResult(string id, string content, bool? userChoosen)
        {
            Id = id;
            UserChoosen = userChoosen;
            Content = content;
        }

        [BsonElement("content")]
        public string Content { get; set; }

        [BsonElement("userChoosen")]
        public bool? UserChoosen { get; set; }
    }
}
