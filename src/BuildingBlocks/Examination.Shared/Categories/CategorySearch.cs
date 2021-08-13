using Examination.Dtos.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Dtos.Categories
{
    public class CategorySearch : PagingParameters
    {
        public string Name { get; set; }
    }
}
