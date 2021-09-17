using System;
using System.Collections.Generic;
using System.Linq;
using Examination.Domain.AggregateModels.QuestionAggregate;
using Examination.Domain.SeedWork;
using Examination.Shared.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Examination.Domain.AggregateModels.ExamAggregate
{
    public class Exam : Entity, IAggregateRoot
    {
        public Exam() { }
        public Exam(string name, string shortDesc, string content, int numberOfQuestions, TimeSpan? duration,
            List<Question> questions, Level level, string ownerUserId, int numberOfQuestionCorrectForPass,
            bool isTimeRestricted, string categoryId, string categoryName)
        {
            (Name, ShortDesc, Content, NumberOfQuestions,
                    Duration, Questions, Level, DateCreated, OwnerUserId, NumberOfQuestionCorrectForPass,
                    IsTimeRestricted, CategoryId, CategoryName)
                = (name, shortDesc, content, numberOfQuestions, duration, questions, level, DateTime.UtcNow,
                    ownerUserId,
                    numberOfQuestionCorrectForPass, isTimeRestricted, categoryId, categoryName);
        }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("shortDesc")]
        public string ShortDesc { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }

        [BsonElement("numberOfQuestions")]
        public int NumberOfQuestions { get; set; }

        [BsonElement("duration")]
        public TimeSpan? Duration { get; set; }

        [BsonElement("questions")]
        public List<Question> Questions { get; set; }

        [BsonElement("level")]
        public Level Level { get; set; }

        [BsonElement("dateCreated")]
        public DateTime DateCreated { get; set; }

        [BsonElement("ownerUserId")]
        public string OwnerUserId { get; set; }

        [BsonElement("numberOfQuestionCorrectForPass")]
        public int NumberOfQuestionCorrectForPass { get; set; }

        [BsonElement("isTimeRestricted")]
        public bool IsTimeRestricted { get; set; }

        [BsonElement("categoryId")]
        public string CategoryId { get; set; }

        [BsonElement("categoryName")]
        public string CategoryName { get; set; }

    }
}