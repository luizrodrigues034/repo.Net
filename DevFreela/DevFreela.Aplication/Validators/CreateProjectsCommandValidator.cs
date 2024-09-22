using DevFreela.Aplication.Commands.CreateProjectCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Validators
{
    public class CreateProjectsCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectsCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("Nao pode ser vazio")
                .MaximumLength(30)
                .WithMessage("O titulo deve conter no maximo 30 caracteres");

            RuleFor(p => p.Description)
                .MinimumLength(30).WithMessage("Deve Conter no minimo 30 caracteres")
                .MaximumLength(200).WithMessage("Deve conte no maximo 200 caracteres")
                .NotEmpty().WithMessage("A descricao nao pode ser vazia");
        }
    }
}
