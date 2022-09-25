using AutoMapper;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Tecnologies.Dtos;
using Application.Features.Tecnologies.Models;
using Domain.Entities;
using Application.Features.Tecnologies.Commands.CreateTechnologies;

namespace Application.Features.Tecnologies.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Technologies, CreatedTechnologiesCommandDto>().ReverseMap();
            CreateMap<Technologies, CreateTechnologiesCommand>().ReverseMap();
            CreateMap<Technologies, DeletedTechnologiesDto>().ReverseMap();
            //CreateMap<Technologies, UpdatedProgrammingLanguageTechnologyDto>()
            //    .ReverseMap();
            //CreateMap<Technologies, ProgrammingLanguageTechnologyGetByIdDto>()
            //    .ForMember(c => c.ProgrammingLanguageName,
            //        opts => opts.MapFrom(o => o.ProgrammingLanguage.Name))
            //    .ReverseMap();
            //CreateMap<Technologies, ProgrammingLanguageTechnologyListDto>()
            //    .ForMember(c => c.ProgrammingLanguageName,
            //        opts => opts.MapFrom(o => o.ProgrammingLanguage.Name))
            //    .ReverseMap();
            CreateMap<IPaginate<Technologies>, TechnologiesListModel>()
                .ReverseMap();
        }
    }
}
