using Microsoft.EntityFrameworkCore;
using VeiculosAPI.Context;
using VeiculosAPI.Repositories;
using VeiculosAPI.Servicos;
using VeiculosAPI.Servicos.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<VendasVeiculoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

builder.Services.AddScoped<ILojaServico, LojaServico>();
builder.Services.AddScoped<IVendaServico, VendaServico>();
builder.Services.AddScoped<IVeiculoServico, VeiculoServico>();
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepositorio>();
builder.Services.AddScoped<ILojaRepository, LojaRepositorio>();
builder.Services.AddScoped<IVendaRepository, VendaRepositorio>();

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
