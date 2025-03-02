using AutoMapper;
using BusinessObjects;
using BusinessObjects.Dtos.User;
using BusinessObjects.DTOs.Articles;
using BusinessObjects.DTOs.Category;
using BusinessObjects.DTOs.Department;
using BusinessObjects.DTOs.Facility;

using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, GeneralUserDto>().ReverseMap();

            CreateMap<Article, NewsArticleDTO>().ReverseMap();
            CreateMap<Category,CategoryDTO>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<FacilityType, FacilityTypeDto>().ReverseMap();
        }
    }
}
