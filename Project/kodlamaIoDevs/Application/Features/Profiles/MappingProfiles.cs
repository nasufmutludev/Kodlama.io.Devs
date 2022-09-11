using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Dtos;
using Application.Features.Models;
using Core.Persistence.Paging;
using Domain.Entities;
using Application.Features.Commands.CreateLanguage;
using Application.Features.Commands.DeleteLanguage;
using Application.Features.Commands.UpdateLanguage;

namespace Application.Features.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Language, CreatedLanguageDto>().ReverseMap();
            CreateMap<Language, CreateLanguageCommand>().ReverseMap();
            CreateMap<Language, LanguageListDto>().ReverseMap();
            CreateMap<Language, GetByIdLanguageDto>().ReverseMap();
            CreateMap<Language, UpdateLanguageDto>().ReverseMap();
            CreateMap<Language, UpdateLanguageCommand>().ReverseMap();
            CreateMap<Language, DeleteLanguageDto>().ReverseMap();
            CreateMap<Language, DeleteLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<Language>, LanguageListModel>().ReverseMap();
        }
    }
}
