﻿using Dapper;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Commands.StartProjectCommand
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;
        public StartProjectCommandHandler(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }
        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);
                project.Starting();
                sqlConnection.Open();
                var script =  "UPDATE Project SET Staus = @status, StartedAt = @startedAt WHERE Id = @id";
                sqlConnection.Execute(script, new { status = project.Status, startedat = project.StartedAt, request.Id });


            }
            return Unit.Value;
        }
    }
}
