using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examination.Shared.Exams;
using Examination.Shared.SeedWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalApp.Services.Interfaces;

namespace PortalApp.Pages.Exams
{
    [Authorize]
    public class ExamListModel : PageModel
    {
        private readonly IExamService _examService;
        
        [BindProperty]
        public PagedList<ExamDto> Exam { set; get; }

        public ExamListModel(IExamService examService)
        {
            _examService = examService;
        }

        public async Task<IActionResult> OnGetAsync([FromQuery] ExamSearch search)
        {
            var result = await _examService.GetExamsPagingAsync(search);
            if (result.IsSuccessed)
            {
                Exam = result.ResultObj;
            }
            return Page();
        }
    }
}
