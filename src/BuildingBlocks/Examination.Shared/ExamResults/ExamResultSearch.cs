using Examination.Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Shared.ExamResults
{
    public class ExamResultSearch : PagingParameters
    {
        public string Keyword { get; set; }
    }
}
