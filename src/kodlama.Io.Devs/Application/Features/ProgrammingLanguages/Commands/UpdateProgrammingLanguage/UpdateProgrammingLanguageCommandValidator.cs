﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandValidator:AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageCommandValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0);
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Version).NotEmpty();
            RuleFor(p => p.Name).MinimumLength(2);
            RuleFor(p => p.Version).MinimumLength(2);
        }
    }
}
