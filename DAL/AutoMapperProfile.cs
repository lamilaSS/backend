using AutoMapper;
using mcq_backend.Controllers;
using mcq_backend.Model;

namespace mcq_backend.DAL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Idoru, IdoruParam>().ReverseMap();
        }
    }
}