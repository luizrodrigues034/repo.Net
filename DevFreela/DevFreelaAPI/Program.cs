using DevFreelaAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<OpeningTimeOption>(builder.Configuration.GetSection("OpeningTime"));
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
