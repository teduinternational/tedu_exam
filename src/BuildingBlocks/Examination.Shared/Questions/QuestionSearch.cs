using Examination.Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Shared.Questions
{
    public class QuestionSearch : PagingParameters
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
    }
}
