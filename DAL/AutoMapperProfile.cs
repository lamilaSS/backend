using System;
using System.Linq.Expressions;
using AutoMapper;
using mcq_backend.Controllers;
using mcq_backend.Dataset.Answer;
using mcq_backend.Dataset.Game;
using mcq_backend.Dataset.Question;
using mcq_backend.Model;
using mcq_backend.Model.Keyless;
using Microsoft.OpenApi.Extensions;

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
            //Ai la ty phu datasets
            CreateMap<Question, AiLaTyPhuQuestionDataset>().ForMember(qdts => qdts.Difficulty,
                m => m.MapFrom(q => (q.Difficulty.GetDisplayName())));
            CreateMap<Answer, AiLaTyPhuAnswerDataset>();
            CreateMap<Game, AiLaTyPhuGameDataset>();
            //EF Core is questionable when it comes to RawSql
            CreateMap<Question, QuestionKeyless>().ReverseMap();
        }
    }
}