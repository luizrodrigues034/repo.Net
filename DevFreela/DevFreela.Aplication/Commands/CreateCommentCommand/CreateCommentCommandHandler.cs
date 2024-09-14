using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Commands.CreateCommentCommand
{
    internal class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        public CreateCommentCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var commentPost =  new ProjectsComment(request.Content, request.IdUser, request.IdProject);
            await _projectRepository.PosteCommentAsync(commentPost);

            return Unit.Value;
        }
    }
}
