﻿using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<OperationClaim> result = await _operationClaimRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Operation Claim name exists.");
        }

        public async Task OperationClaimShouldExistWhenRequested(OperationClaim operationClaim)
        {

            if (operationClaim == null) throw new BusinessException("Request Operation Claim does not exists.");
        }
    }
}
