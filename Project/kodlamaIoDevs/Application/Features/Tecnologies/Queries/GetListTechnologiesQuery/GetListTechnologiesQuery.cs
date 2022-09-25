using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Tecnologies.Models;
using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Application.Features.Languages.Models;
using Application.Features.Languages.Queries.GetListLanguage;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Tecnologies.Queries.GetListTechnologiesQuery
{
    public class GetListTechnologiesQuery : IRequest<TechnologiesListModel>
    {
        //public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListTechnologiesQueryHandler : IRequestHandler<
            GetListTechnologiesQuery, TechnologiesListModel>
        {
            private readonly ITechnologiesRepository _technologiesRepository;
            private readonly IMapper _mapper;

            public GetListTechnologiesQueryHandler(ITechnologiesRepository technologiesRepository, IMapper mapper)
            {
                _technologiesRepository = technologiesRepository;
                _mapper = mapper;
            }

            //public async Task<TechnologiesListModel> Handle(GetListTechnologiesQuery request,
            //    CancellationToken cancellationToken)
            //{
            //    var technologies = await _technologiesRepository
            //        .GetListByDynamicAsync(
            //            dynamic: request.Dynamic,
            //            include: m => m.Include(c => c.Name),
            //            index: request.PageRequest.Page,
            //            size: request.PageRequest.PageSize);

            //    var mappedTechnologies = _mapper.Map<TechnologiesListModel>(technologies);

            //    return mappedTechnologies;
            //}

            public async Task<TechnologiesListModel> Handle(GetListTechnologiesQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Technologies> technologies = await _technologiesRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                TechnologiesListModel mappedTechnologiesModel = _mapper.Map<TechnologiesListModel>(technologies);
                return mappedTechnologiesModel;
            }
        }
    }
}

