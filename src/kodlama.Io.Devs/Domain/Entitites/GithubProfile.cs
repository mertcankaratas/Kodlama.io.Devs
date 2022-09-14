using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitites
{
    public class GithubProfile:Entity
    {

        public int UserId { get; set; }
        public int RepoName { get; set; }
        public int RepoUrl { get; set; }

        public GithubProfile()
        {

        }

        public GithubProfile(int id,int userId, int repoName, int repoUrl):this()
        {
            Id = id;
            UserId = userId;
            RepoName = repoName;
            RepoUrl = repoUrl;
        }
    }
}
