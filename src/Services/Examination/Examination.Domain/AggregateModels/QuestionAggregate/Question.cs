using System;
using System.Collections.Generic;
using System.Linq;
using Examination.Domain.SeedWork;
using Examination.Dtos.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Examination.Domain.AggregateModels.QuestionAggregate
{
    public class Question : Entity, IAggregateRoot
    {
        public Question(string id, string content, QuestionType questionType, Level level, string categoryId,
            IEnumerable<Answer> answers, string explain, string ownerUserId = null)
        {
            if (answers == null && !answers.Any())
                throw new ArgumentNullException($"{nameof(answers)} can not be null.");

            if (questionType == QuestionType.SingleSelection && answers.Count(x => x.IsCorrect) > 1)
                throw new ArgumentNullException($"{nameof(answers)} is invalid.");

            (Id, Content, QuestionType, Level, CategoryId, Answers, Explain, DateCreated, OwnerUserId) = (id, content,
                questionType, level, categoryId, answers, explain, DateTime.UtcNow, ownerUserId);
        }

        [BsonElement("content")]
        public string Content { get; set; }

        [BsonElement("questionType")]
        public QuestionType QuestionType { get; set; }

        [BsonElement("level")]
        public Level Level { set; get; }

        [BsonElement("categoryId")]
        public string CategoryId { get; set; }

        [BsonElement("answers")]
        public IEnumerable<Answer> Answers { set; get; }

        [BsonElement("explain")]
        public string Explain { get; set; }

        [BsonElement("dateCreated")]
        public DateTime DateCreated { get; set; }

        [BsonElement("ownerUserId")]
        public string OwnerUserId { get; set; }
    }
}