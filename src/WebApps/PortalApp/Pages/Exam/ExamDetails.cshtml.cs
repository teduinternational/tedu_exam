using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examination.Shared.Exams;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalApp.Services.Interfaces;

namespace PortalApp.Pages.Exam
{
    public class ExamDetailsModel : PageModel
    {
        private readonly IExamService _examService;

        [BindProperty]
        public ExamDto Exam { set; get; }

        public ExamDetailsModel(IExamService examService)
        {
            _examService = examService;
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

        public void OnPost()
        {
        }
    }
}
