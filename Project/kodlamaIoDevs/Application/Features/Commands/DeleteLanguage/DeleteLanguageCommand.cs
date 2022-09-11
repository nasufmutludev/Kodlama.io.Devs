using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Dtos;
using Application.Features.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.DeleteLanguage
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
                Language mappedLanguage = _mapper.Map<Language>(request);
                Language language = await _languageRepository.GetAsync(x => x.Id == request.Id);
                _languageBusinessRules.LanguageShouldExistWhenRequested(language);
                Language deleteLanguage = await _languageRepository.DeleteAsync(mappedLanguage);
                DeleteLanguageDto deleteLanguageDto = _mapper.Map<DeleteLanguageDto>(deleteLanguage);
                return deleteLanguageDto;
            }
        }
    }
}
