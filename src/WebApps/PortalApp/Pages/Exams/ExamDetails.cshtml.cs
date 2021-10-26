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
    public class ExamDetailsModel : PageModel
    {
        private readonly IExamService _examService;
        private readonly IExamResultService _examResultService;
        [BindProperty]
        public ExamDto Exam { set; get; }

        public ExamDetailsModel(IExamService examService, IExamResultService examResultService)
        {
            _examService = examService;
            _examResultService = examResultService;
        }

        public async Task<IActionResult> OnGet(string id)
        {
            var result = await _examService.GetExamByIdAsync(id);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }

            Exam = result.ResultObj;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _examResultService.StartExamAsync(new StartExamRequest()
            {
                ExamId = Exam.Id
            });
            if (result.IsSuccessed)
            {
                return Redirect($"/take-exam.html?examResultId={result.ResultObj.Id}");
            }
            return Page();
        }
    }
}
