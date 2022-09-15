﻿using Application.Features.GithubProfiles.Dtos;
using Application.Features.GithubProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubProfiles.Commands.DeleteGithubProfile
{
    public class DeleteGithubProfileCommand:IRequest<DeletedGithubProfileDto>
    {
        public int Id { get; set; }

        public class DeleteGithubProfileCommandHandler : IRequestHandler<DeleteGithubProfileCommand, DeletedGithubProfileDto>
        {
            private readonly IGithubProfileRepository _githubProfileRepository;
            private readonly IMapper _mapper;
            private readonly GithubProfileBusinessRules _githubProfileBusinessRules;

            public DeleteGithubProfileCommandHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper, GithubProfileBusinessRules githubProfileBusinessRules)
            {
                _githubProfileRepository = githubProfileRepository;
                _mapper = mapper;
                _githubProfileBusinessRules = githubProfileBusinessRules;
            }

            public async Task<DeletedGithubProfileDto> Handle(DeleteGithubProfileCommand request, CancellationToken cancellationToken)
            {
                GithubProfile? githubProfile = await _githubProfileRepository.GetAsync(x => x.Id == request.Id);

                await _githubProfileBusinessRules.GithubProfileShouldExistWhenRequested(githubProfile);

                GithubProfile deletedGithubProfile = await _githubProfileRepository.DeleteAsync(githubProfile);
                DeletedGithubProfileDto deletedGithubProfileDto = _mapper.Map<DeletedGithubProfileDto>(deletedGithubProfile);
                return deletedGithubProfileDto;
            }
        }
    }
}
