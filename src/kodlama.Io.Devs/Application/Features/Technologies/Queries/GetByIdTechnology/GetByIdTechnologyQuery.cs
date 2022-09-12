﻿using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetByIdTechnology
{
    public class GetByIdTechnologyQuery:IRequest<TechnologyGetByIdDto>
    {
        public int Id { get; set; }


        public class GetByIdTechnologyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, TechnologyGetByIdDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public GetByIdTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<TechnologyGetByIdDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
            {

                await _technologyBusinessRules.TechnologyShouldExistWhenRequested(request.Id);
                Technology? technology = await _technologyRepository.GetAsync(t=>t.Id==request.Id);
                TechnologyGetByIdDto mappedTechnologyGetByIdDto = _mapper.Map<TechnologyGetByIdDto>(technology);    


                    
                return mappedTechnologyGetByIdDto;
            }
        }
    }
}
