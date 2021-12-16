namespace Examination.Shared.SeedWork
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult()
        {
        }
        public ApiSuccessResult(T resultObj) : base(true, resultObj)
        {
        }
        public ApiSuccessResult(T resultObj, string message) : base(true, resultObj, message)
        {
        }
    }
}
