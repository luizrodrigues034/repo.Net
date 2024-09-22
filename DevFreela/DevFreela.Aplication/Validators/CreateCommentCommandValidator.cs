using DevFreela.Aplication.Commands.CreateCommentCommand;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Validators
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(f => f.Content).NotEmpty().WithMessage("O valor nao pode ser nulo").MaximumLength(200);

            RuleFor(f => f.IdProject).NotNull().WithMessage("O valor do proejto nao pode ser nulo");

            RuleFor(f => f.IdUser).NotNull().WithMessage("O valor do proejto nao pode ser nulo");

        }
    }
}
