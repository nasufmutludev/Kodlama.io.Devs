using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Rules;
using Application.Services.Repositories;

namespace Application.Features.Tecnologies.Rules
{
    public class TechnologiesBusinessRules
    {
        private readonly ITechnologiesRepository _technologiesRepository;
        private readonly LanguageBusinessRules _languageBusinessRules;


        public TechnologiesBusinessRules(ITechnologiesRepository technologiesRepository, LanguageBusinessRules languageBusinessRules)
        {
            _technologiesRepository = technologiesRepository;
            _languageBusinessRules = languageBusinessRules;
        }

        public async Task NameAlreadyExistBySpecificProgrammingLanguageId(int programmingLanguageId, string name)
        {
            var result = await _technologiesRepository
                .GetAsync(w => w.LanguageId == programmingLanguageId &&
                               w.Name.Equals(name));

            if (result != null)
                throw new BusinessException(
                    $"Name already exist for this programming language id: {programmingLanguageId}");
        }

        public async Task HasProgrammingLanguageWithThisIs(int languageId)
        {
            await _languageBusinessRules.LanguageShouldBeExist(languageId);
        }

        public async Task HasProgrammingLanguageTechnologyWithThisId(int programmingLanguageTechnologyId)
        {
            var result = await
                _technologiesRepository.GetAsync(w => w.Id == programmingLanguageTechnologyId);

            if (result == null)
                throw new BusinessException(
                    $"There is not programming language technology with this id {programmingLanguageTechnologyId}");
        }
    }
}
