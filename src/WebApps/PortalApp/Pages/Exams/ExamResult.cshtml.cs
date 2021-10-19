using System.Threading.Tasks;
using Examination.Shared.ExamResults;
using Examination.Shared.Exams;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalApp.Services.Interfaces;

namespace PortalApp.Pages.Exams
{
    public class ExamResultModel : PageModel
    {
        private readonly IExamResultService _examResultService;
        private readonly IExamService _examService;

        [BindProperty]
        public ExamResultDto ExamResult { set; get; }

        [BindProperty]
        public ExamDto Exam { set; get; }

        public ExamResultModel(IExamResultService examResultService, IExamService examService)
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
    }
}
