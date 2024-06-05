using Microsoft.EntityFrameworkCore;
using VeiculosAPI.Context;
using VeiculosAPI.Extensions;
using VeiculosAPI.Mappings;
using VeiculosAPI.Repositories;
using VeiculosAPI.Repositories.Interfaces;
using VeiculosAPI.Servicos;
using VeiculosAPI.Servicos.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSql(builder.Configuration)
        .AddRepository()
        .AddService();


builder.Services.AddAutoMapper(typeof(EntitiesToDtoMappingProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
