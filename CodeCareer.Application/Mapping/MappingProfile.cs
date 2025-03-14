using AutoMapper;
using CodeCareer.Application.DTOs;
using CodeCareer.Posts;
using CodeCareer.Recruiters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Recruiter, RecruiterDTO>().ReverseMap();
            CreateMap<Post, PostDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
