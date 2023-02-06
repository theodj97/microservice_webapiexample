using AutoMapper;
using Domain.Entities;
using MicroServiceAPITutorial.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CategoryDTO, Category>();
            CreateMap<BlogPostDTO, BlogPost>();
        }
    }
}
