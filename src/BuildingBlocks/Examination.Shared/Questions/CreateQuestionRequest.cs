using Examination.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Shared.Questions
{
    public class CreateQuestionRequest
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public QuestionType QuestionType { get; set; }

        [Required]
        public Level Level { set; get; }

        [Required]
        public string CategoryId { get; set; }

        [Required]
        public List<AnswerDto> Answers { set; get; } = new List<AnswerDto>();

        public string Explain { get; set; }
    }
}
