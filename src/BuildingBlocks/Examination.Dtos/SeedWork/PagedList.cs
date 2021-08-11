using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Dtos.SeedWork
{
    public class PagedList<T>
    {
        public MetaData MetaData { get; set; }
        public List<T> Items { set; get; }

        public PagedList() { }
        public PagedList(List<T> items, long count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };
            Items = items;
        }
    }
}
