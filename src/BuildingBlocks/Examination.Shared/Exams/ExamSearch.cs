using Examination.Shared.SeedWork;

namespace Examination.Shared.Questions
{
    public class ExamSearch : PagingParameters
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
    }
}
