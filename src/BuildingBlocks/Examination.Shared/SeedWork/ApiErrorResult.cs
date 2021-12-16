using System;
using System.Collections.Generic;
using System.Linq;

namespace Examination.Shared.SeedWork
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public List<string> Errors { set; get; }
        public ApiErrorResult(string message)
          : base(false, message)
        {
        }

        public ApiErrorResult(List<string> errors)
        : base(false)
        {
            Errors = errors;
        }
    }
}
