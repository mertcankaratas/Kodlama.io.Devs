using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommandValidator:AbstractValidator<CreateTechnologyCommand>
    {
        public CreateTechnologyCommandValidator()
        {

            RuleFor(p => p.ProgrammingLanguageId).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Version).NotEmpty();

            RuleFor(p => p.ProgrammingLanguageId).GreaterThan(0);
            RuleFor(p => p.Name).MinimumLength(2);
            RuleFor(p => p.Version).MinimumLength(2);
        }
    }
}
