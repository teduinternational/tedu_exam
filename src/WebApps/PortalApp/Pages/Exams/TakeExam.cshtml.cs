using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examination.Shared.ExamResults;
using Examination.Shared.Exams;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalApp.Services.Interfaces;

namespace PortalApp.Pages.Exams
{
    [IgnoreAntiforgeryToken(Order = 1001)]
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

        public async Task<IActionResult> OnGetQuestion(string examResultId, int questionIndex)
        {
            var examResult = await _examResultService.GetExamResultByIdAsync(examResultId);
            if (examResult.IsSuccessed)
            {
                return new JsonResult(examResult.ResultObj.QuestionResults[questionIndex]);
            }
            return BadRequest();
        }

        public async Task<IActionResult> OnPostSkipExamAsync([FromBody] SkipExamRequest request)
        {
            var exam = await _examResultService.SkipExamAsync(request);
            if (exam.IsSuccessed)
            {
                return new JsonResult(exam);
            }
            return BadRequest();
        }

        public async Task<IActionResult> OnPostFinishExamAsync([FromBody] FinishExamRequest request)
        {
            var exam = await _examResultService.FinishExamAsync(request);
            if (exam.IsSuccessed)
            {
                return new JsonResult(exam);
            }
            return BadRequest();
        }

        public async Task<IActionResult> OnPostNextQuestionAsync([FromBody] NextQuestionRequest request)
        {
            var exam = await _examResultService.NextQuestionAsync(request);
            if (exam.IsSuccessed)
            {
                return new JsonResult(exam);
            }
            return BadRequest();
        }
    }
}
