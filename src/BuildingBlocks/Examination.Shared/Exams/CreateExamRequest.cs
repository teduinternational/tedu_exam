using Examination.Shared.Enums;
using Examination.Shared.Questions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Shared.Exams
{
    public class CreateExamRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortDesc { get; set; }

        public string Content { get; set; }

        [Required]
        public int NumberOfQuestions { get; set; }

        public string Duration { get; set; }

        public List<QuestionDto> Questions { get; set; }

        [Required]
        public Level Level { get; set; }

        [Required]
        public int NumberOfQuestionCorrectForPass { get; set; }

        [Required]
        public bool IsTimeRestricted { get; set; }

        public bool AutoGenerateQuestion { set; get; }

        [Required]
        public string CategoryId { get; set; }

    }
}