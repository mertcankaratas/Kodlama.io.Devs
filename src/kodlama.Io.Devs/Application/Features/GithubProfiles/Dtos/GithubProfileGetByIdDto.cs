﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubProfiles.Dtos
{
    public class GithubProfileGetByIdDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RepoName { get; set; }
        public int RepoUrl { get; set; }
    }
}