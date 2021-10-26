using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Shared.ExamResults
{
    public class ExamResultDto
    {
        public string Id { set; get; }
        public string ExamId { get; set; }

        public string ExamTitle { set; get; }

        public string UserId { set; get; }

        public string Email { set; get; }

        public string FullName { set; get; }

        public List<QuestionResultDto> QuestionResults { get; set; }

        public DateTime ExamStartDate { get; set; }

        public DateTime? ExamFinishDate { get; set; }

        public bool? Passed { get; set; }

        public bool Finished { get; set; }
    }
}