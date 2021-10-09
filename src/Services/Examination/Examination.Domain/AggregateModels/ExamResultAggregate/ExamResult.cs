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

        [BsonElement("userId")]
        public string UserId { set; get; }

        [BsonElement("examQuestionReviews")]
        public IEnumerable<ExamResultDetail> ExamResultDetails { get; set; }

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