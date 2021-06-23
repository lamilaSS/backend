using AutoMapper;
using mcq_backend.Controllers;
using mcq_backend.Dataset.Answer;
using mcq_backend.Dataset.Question;
using mcq_backend.Model;

namespace mcq_backend.DAL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Idoru, IdoruParam>().ReverseMap();
            CreateMap<Question, QuestionCreate>().ReverseMap();
            CreateMap<Answer, AnswerCreate>().ReverseMap();
            CreateMap<Question, QuestionDataset>().ReverseMap();
            CreateMap<Answer, AnswerDataset>().ReverseMap();
        }
    }
}