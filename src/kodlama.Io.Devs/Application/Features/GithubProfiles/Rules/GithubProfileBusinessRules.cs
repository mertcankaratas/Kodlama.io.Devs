using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubProfiles.Rules
{
    public class GithubProfileBusinessRules
    {
        private readonly IGithubProfileRepository _githubProfileRepository;

        public GithubProfileBusinessRules(IGithubProfileRepository githubProfileRepository)
        {
            _githubProfileRepository = githubProfileRepository;
        }

        public async Task GithubProfileCanNotBeDuplicatedWhenInserted(string url)
        {
            IPaginate<GithubProfile> result = await _githubProfileRepository.GetListAsync(b => b.RepoUrl == url);
            if (result.Items.Any()) throw new BusinessException("Github Profile exists.");
        }

        public async Task GithubProfileShouldExistWhenRequested(GithubProfile githubProfile)
        {
            if(githubProfile==null) throw new BusinessException("Request GithubProfile does not exists.");
        }
    }
}
