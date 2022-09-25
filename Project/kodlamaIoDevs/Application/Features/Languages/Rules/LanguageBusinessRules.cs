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

        public void LanguageShouldExistWhenRequested(Language language)
        {
            if (language == null) throw new BusinessException("Requested language does not exists.");
        }

        public async Task LanguageShouldBeExist(int id)
        {
            var result = await _languageRepository.GetAsync(w => w.Id == id);
            if (result is null) throw new BusinessException($"There is no programming language with id {id}");
        }

        public async Task HasLanguageWithThisId(int languageId)
        {
            var result = await
                _languageRepository.GetAsync(w => w.Id == languageId);

            if (result == null)
                throw new BusinessException(
                    $"There is not programming language with this id {languageId}");
        }
    }
}
