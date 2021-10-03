using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PortalApp.Pages.Exam
{
    [Authorize]
    public class ExamListModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
