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
            CreateMap<Technologies, UpdatedTechnologiesDto>().ReverseMap();
            CreateMap<Technologies, TechnologiesGetByIdDto>().ForMember(c => c.Name,opts => opts.MapFrom(o => o.LanguageId)).ReverseMap();
            CreateMap<Technologies, TechnologiesListDto>().ReverseMap();
            CreateMap<IPaginate<Technologies>, TechnologiesListModel>()
                .ReverseMap();
        }
    }
}
