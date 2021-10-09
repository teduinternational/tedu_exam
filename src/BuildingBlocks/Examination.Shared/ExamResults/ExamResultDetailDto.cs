using Examination.Shared.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Shared.ExamResults
{
    public class ExamResultDetailDto
    {
        public QuestionDto Question { get; set; }
        public IEnumerable<AnswerDto> SelectedAnswers { get; set; }
        public bool IsCorrect { get; set; }
    }
}
