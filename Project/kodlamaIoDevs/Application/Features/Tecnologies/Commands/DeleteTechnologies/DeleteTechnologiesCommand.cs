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

namespace Application.Features.Tecnologies.Commands.DeleteTechnologies
{
    public class DeleteTechnologiesCommand : IRequest<DeletedTechnologiesDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguageTechnologyCommandHandler : IRequestHandler<
            DeleteTechnologiesCommand, DeletedTechnologiesDto>
        {
            private readonly ITechnologiesRepository _technologiesRepository;
            private readonly IMapper _mapper;
            private readonly TechnologiesBusinessRules _technologiesBusinessRules;


            public DeleteProgrammingLanguageTechnologyCommandHandler(ITechnologiesRepository technologiesRepository, IMapper mapper, TechnologiesBusinessRules technologiesBusinessRules)
            {
                _technologiesRepository = technologiesRepository;
                _mapper = mapper;
                _technologiesBusinessRules = technologiesBusinessRules;
            }

            public async Task<DeletedTechnologiesDto> Handle(
                DeleteTechnologiesCommand request,
                CancellationToken cancellationToken)
            {
                await _technologiesBusinessRules.HasProgrammingLanguageTechnologyWithThisId(request.Id);

                var TechnologiesEntity = await _technologiesRepository.GetAsync(w => w.Id == request.Id);
                var deletedTechnologies = await _technologiesRepository.DeleteAsync(TechnologiesEntity);
                var deletedTechnologiesDto = _mapper.Map<DeletedTechnologiesDto>(deletedTechnologies);

                return deletedTechnologiesDto;
            }
        }
    }
}
