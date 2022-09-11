using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Rules
{
    public class LanguageBusinessRules
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task LanguageCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Language> result = await _languageRepository.GetListAsync(x => x.Name == name);
            if (result.Items.Any()) throw new BusinessException("Language name exists.");
        }

        public async Task LanguageShouldExistWhenRequested(int id)
        {
            Language language = await _languageRepository.GetAsync(x => x.Id == id);
            if (language == null) throw new BusinessException("Requested language does not exists.");
        }
    }
}
