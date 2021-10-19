using Examination.Shared.Enums;
using Examination.Shared.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Shared.ExamResults
{
    public class QuestionResultDto
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public QuestionType QuestionType { get; set; }
        public Level Level { get; set; }
        public string Explain { get; set; }
        public List<AnswerResultDto> Answers { set; get; }
        public bool? Result { get; set; }
    }
}