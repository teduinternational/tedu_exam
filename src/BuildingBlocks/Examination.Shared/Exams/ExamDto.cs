using System;

namespace Examination.Dtos.Exams
{
    public class ExamDto
    {
        public string Id { set; get; }
        public string Name { get; set; }

        public string ShortDesc { get; set; }

        public int NumberOfQuestions { get; set; }

        public TimeSpan? Duration { get; set; }

        public Enums.Level Level { get; set; }

        public DateTime DateCreated { get; set; }
    }
}