using DevFreela.Core.Entities;
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
        private readonly DevFreelaDbContext _dbContext;
        public CreateCommentCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var commentPost =  new ProjectsComment(request.Content, request.IdUser, request.IdProject);
            await _dbContext.ProjectsComments.AddAsync(commentPost);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
