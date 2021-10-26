using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Shared.SeedWork
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult()
        {
        }
        public ApiSuccessResult(int statusCode, T resultObj) : base(statusCode, true, resultObj)
        {
        }
        public ApiSuccessResult(int statusCode, T resultObj, string message) : base(statusCode, true, resultObj, message)
        {
        }
    }
}
