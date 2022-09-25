using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Languages.Dtos;
using Application.Features.Rules;
using Application.Features.Tecnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommand:IRequest<DeleteLanguageDto>
    {
        public int Id { get; set; }
        public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeleteLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;


            public DeleteLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<DeleteLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {
                await _languageBusinessRules.HasLanguageWithThisId(request.Id);
                var LanguageEntity = await _languageRepository.GetAsync(w =>
                    w.Id == request.Id);
                var deletedLanguage = await _languageRepository.DeleteAsync(LanguageEntity);
                var deletedLanguageDto =
                    _mapper.Map<DeleteLanguageDto>(deletedLanguage);

                return deletedLanguageDto;
            }
        }
    }
}
