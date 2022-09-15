﻿using Application.Features.GithubProfiles.Commands.CreateGithubProfile;
using Application.Features.GithubProfiles.Commands.UpdateGithubProfile;
using Application.Features.GithubProfiles.Dtos;
using Application.Features.GithubProfiles.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubProfiles.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<GithubProfile, CreateGithubProfileCommand>().ReverseMap();
            CreateMap<GithubProfile, CreatedGithubProfileDto>().ReverseMap();

            CreateMap<GithubProfile, CreateGithubProfileCommand>().ReverseMap();
            CreateMap<GithubProfile,DeletedGithubProfileDto>().ReverseMap();

            CreateMap<GithubProfile, UpdateGithubProfileCommand>().ReverseMap();        
            CreateMap<GithubProfile,UpdatedGithubProfileDto>().ReverseMap();

            CreateMap<IPaginate<GithubProfile>, GithubProfileListModel>().ReverseMap();
            CreateMap<GithubProfile, GithubProfileListDto>().ReverseMap();
        }
    }
}
