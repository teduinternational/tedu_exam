using AutoMapper;
using Examination.Domain.AggregateModels.CategoryAggregate;
using Examination.Domain.AggregateModels.ExamAggregate;
using Examination.Domain.AggregateModels.ExamResultAggregate;
using Examination.Domain.AggregateModels.QuestionAggregate;
using Examination.Shared.Categories;
using Examination.Shared.ExamResults;
using Examination.Shared.Exams;
using Examination.Shared.Questions;

namespace Examination.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Exam, ExamDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<Answer, AnswerDto>().ReverseMap();
            CreateMap<ExamResult, ExamResultDto>().ReverseMap();
            CreateMap<QuestionResult, QuestionResultDto>().ReverseMap();
            CreateMap<AnswerResult, AnswerResultDto>().ReverseMap();
        }
    }
}