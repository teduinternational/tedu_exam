using System.Threading.Tasks;
using Examination.Shared.ExamResults;
using Examination.Shared.Exams;
using Examination.Shared.Questions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalApp.Services.Interfaces;

namespace PortalApp.Pages.Exams
{
    public class TakeExamModel : PageModel
    {
        private readonly IExamResultService _examResultService;
        private readonly IExamService _examService;
        [BindProperty]
        public ExamResultDto ExamResult { set; get; }

        [BindProperty]
        public ExamDto Exam { set; get; }

        public TakeExamModel(IExamResultService examResultService, IExamService examService)
        {
            _examResultService = examResultService;
            _examService = examService;
        }

        public async Task OnGetAsync(string examResultId)
        {
            var result = await _examResultService.GetExamResultByIdAsync(examResultId);
            if (result.IsSuccessed)
            {
                ExamResult = result.ResultObj;

                var exam = await _examService.GetExamByIdAsync(ExamResult.ExamId);
                if (exam.IsSuccessed) { Exam = exam.ResultObj; }
            }
        }

        public async Task<IActionResult> OnGetQuestion(string examId, int questionIndex)
        {
            var exam = await _examService.GetExamByIdAsync(examId);
            if (exam.IsSuccessed)
            {
                return new JsonResult(exam.ResultObj.Questions[questionIndex]);
            }
            return BadRequest();
        }
    }
}
