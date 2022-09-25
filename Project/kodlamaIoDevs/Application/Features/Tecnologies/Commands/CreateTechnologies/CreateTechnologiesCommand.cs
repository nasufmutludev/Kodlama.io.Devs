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

namespace Application.Features.Tecnologies.Commands.CreateTechnologies
{
    public class CreateTechnologiesCommand : IRequest<CreatedTechnologiesCommandDto>
    {
        public string Name { get; set; }
        public int LanguageId { get; set; }

        public class
            CreateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<CreateTechnologiesCommand,
                CreatedTechnologiesCommandDto>
        {
            private readonly ITechnologiesRepository _technologiesRepository;
            private readonly IMapper _mapper;
            private readonly TechnologiesBusinessRules _technologyBusinessRules;

            public CreateProgrammingLanguageTechnologyCommandHandler(ITechnologiesRepository technologiesRepository, IMapper mapper, TechnologiesBusinessRules technologiesBusinessRules)
            {
                _technologiesRepository = technologiesRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologiesBusinessRules;
            }

            public async Task<CreatedTechnologiesCommandDto> Handle(CreateTechnologiesCommand request, CancellationToken cancellationToken)
            {
                await _technologyBusinessRules.NameAlreadyExistBySpecificProgrammingLanguageId(request.LanguageId, request.Name);
                await _technologyBusinessRules.HasProgrammingLanguageWithThisIs(request.LanguageId);
                var createdTechnologies = _mapper.Map<Domain.Entities.Technologies>(request);
                var result = await _technologiesRepository.AddAsync(createdTechnologies);
                var createdTechnologiesDto = _mapper.Map<CreatedTechnologiesCommandDto>(createdTechnologies);

                return createdTechnologiesDto;
            }
        }
    }
}
