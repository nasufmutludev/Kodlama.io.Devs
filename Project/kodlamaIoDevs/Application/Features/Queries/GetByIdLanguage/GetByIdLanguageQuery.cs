using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQuery:IRequest<GetByIdLanguageDto>
    {
        public int ID { get; set; }

        public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery, GetByIdLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;

            public GetByIdLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdLanguageDto> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
            {
                Language language = await _languageRepository.GetAsync(x => x.Id == request.ID);
                GetByIdLanguageDto brandGetByIdDto = _mapper.Map<GetByIdLanguageDto>(language);
                return brandGetByIdDto;
            }
        }
    }
}
