using Examination.Dtos.SeedWork;

namespace Examination.Dtos.Questions
{
    public class QuestionSearch : PagingParameters
    {
        public string Name { get; set; }

        public string CategoryId { get; set; }
    }
}
