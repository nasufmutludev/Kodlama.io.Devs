using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Tecnologies.Dtos;
using Application.Features.Tecnologies.Rules;
using Application.Services.Repositories;

namespace Application.Features.Tecnologies.Queries.GetByIdTechnologiesQuery
{
    public class GetByIdTechnologiesQuery : IRequest<TechnologiesGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdTechnologiesQueryHandler : IRequestHandler<
            GetByIdTechnologiesQuery, TechnologiesGetByIdDto>
        {
            private readonly ITechnologiesRepository _technologiesRepository;
            private readonly IMapper _mapper;
            private readonly TechnologiesBusinessRules _technologiesBusinessRules;


            public GetByIdTechnologiesQueryHandler(ITechnologiesRepository technologiesRepository, IMapper mapper, TechnologiesBusinessRules technologyBusinessRules)
            {
                _technologiesRepository = technologiesRepository;
                _mapper = mapper;
                _technologiesBusinessRules = technologyBusinessRules;
            }

            public async Task<TechnologiesGetByIdDto> Handle(GetByIdTechnologiesQuery request, CancellationToken cancellationToken)
            {
                await _technologiesBusinessRules.HasProgrammingLanguageTechnologyWithThisId(request.Id);

                var technologiesEntity = await _technologiesRepository.GetAsync(w => w.Id == request.Id);
                var technologiesDto = _mapper.Map<TechnologiesGetByIdDto>(technologiesEntity);

                return technologiesDto;
            }
        }
    }
}
