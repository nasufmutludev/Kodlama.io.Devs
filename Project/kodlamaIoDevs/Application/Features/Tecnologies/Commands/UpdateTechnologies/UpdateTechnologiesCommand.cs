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

namespace Application.Features.Tecnologies.Commands.UpdateTechnologies
{
    public class UpdateTechnologiesCommand : IRequest<UpdatedTechnologiesDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LanguageId { get; set; }

        public class UpdateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<
            UpdateTechnologiesCommand, UpdatedTechnologiesDto>
        {
            private readonly ITechnologiesRepository _technologiesRepository;
            private readonly IMapper _mapper;
            private readonly TechnologiesBusinessRules _technologiesBusinessRules;


            public UpdateProgrammingLanguageTechnologyCommandHandler(ITechnologiesRepository technologiesRepository, IMapper mapper, TechnologiesBusinessRules technologiesBusinessRules)
            {
                _technologiesRepository = technologiesRepository;
                _mapper = mapper;
                _technologiesBusinessRules = technologiesBusinessRules;
            }

            public async Task<UpdatedTechnologiesDto> Handle(UpdateTechnologiesCommand request, CancellationToken cancellationToken)
            {
                await _technologiesBusinessRules.HasProgrammingLanguageTechnologyWithThisId(request.Id);
                await _technologiesBusinessRules.HasProgrammingLanguageWithThisIs(request.LanguageId);
                await _technologiesBusinessRules.NameAlreadyExistBySpecificProgrammingLanguageId(request.LanguageId, request.Name);

                var technologiesEntity = await _technologiesRepository.GetAsync(w => w.Id == request.Id);
                technologiesEntity.Name = request.Name;
                technologiesEntity.LanguageId = request.LanguageId;

                var updatedTechnologiesEntity = await _technologiesRepository.UpdateAsync(technologiesEntity);
                var updatedTechnologiesDto = _mapper.Map<UpdatedTechnologiesDto>(updatedTechnologiesEntity);

                return updatedTechnologiesDto;
            }
        }
    }
}
