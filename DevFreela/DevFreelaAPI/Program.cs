using DevFreelaAPI.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using FluentAssertions.Common;
using MediatR;
using DevFreela.Aplication.Commands.CreateProjectCommand;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Repositories;
using DevFreela.Aplication.Validators;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using DevFreelaAPI.Filters;
using DevFreela.Core.Authentication;
using DevFreela.Infrastructure.Authentication;
using DevFreela.Aplication.Commands.CreateUser;
using DevFreela.Aplication.Commands.CreateCommentCommand;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DevFreelaCs");
builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ISkillsRepository, SkillsRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies((typeof(CreateCommentCommand).Assembly)));




//builder.Services.AddSingleton<ExempleClass>(e => new ExempleClass { Name = "Joao"});
builder.Services.AddScoped<ExempleClass>(e => new ExempleClass { Name = "Joao" });
// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilters)))
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateProjectsCommandValidator>());


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DevFreela.API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header usando o esquema bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
                           new OpenApiSecurityScheme
                             {
                                 Reference = new OpenApiReference
                                 {
                                     Type = ReferenceType.SecurityScheme,
                                     Id = "Bearer"
                                 }
                             },
                             new string[] {}
                     }
                 });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
