using Application.Services.Repositories;
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
    }
}
