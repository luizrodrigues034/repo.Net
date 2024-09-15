using DevFreelaAPI.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using FluentAssertions.Common;
using MediatR;
using DevFreela.Aplication.Commands.CreateProjectCommand;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DevFreelaCs");
builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ISkillsRepository, SkillsRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();



//builder.Services.AddSingleton<ExempleClass>(e => new ExempleClass { Name = "Joao"});
builder.Services.AddScoped<ExempleClass>(e => new ExempleClass { Name = "Joao" });
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//obuilder esta acessando de forma direta a Option e esta acesado a secao OpningTime, e esta atribuindo os valores definidos
//no arquvivo json para os da Option, deixando disponivel para usar no projeto
//esta acontecendo uma instaciacao de forma automatica


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
