using System;
using System.Collections.Generic;
using Examination.Domain.Events;
using Examination.Domain.SeedWork;
using MongoDB.Bson.Serialization.Attributes;

namespace Examination.Domain.AggregateModels.ExamResultAggregate
{
    public class ExamResult : Entity, IAggregateRoot
    {
        public ExamResult(string userId, string examId) =>
            (UserId, ExamId, ExamStartDate, Finished) = (userId, examId, DateTime.Now, false);

        [BsonElement("examId")]
        public string ExamId { get; set; }

        [BsonElement("examTitle")]
        public string ExamTitle { get; set; }

        [BsonElement("userId")]
        public string UserId { set; get; }

        [BsonElement("email")]
        public string Email { set; get; }

        [BsonElement("fullName")]
        public string FullName { set; get; }

        [BsonElement("questionResults")]
        public List<QuestionResult> QuestionResults { get; set; }

        [BsonElement("correctQuestionCount")]
        public int CorrectQuestionCount { get; set; }

        [BsonElement("examDate")]
        public DateTime ExamStartDate { get; set; }

        [BsonElement("examFinishDate")]
        public DateTime? ExamFinishDate { get; set; }

        [BsonElement("passed")]
        public bool? Passed { get; set; }

        [BsonElement("finished")]
        public bool Finished { get; set; }
    }
}