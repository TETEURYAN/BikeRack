using Microsoft.EntityFrameworkCore;
using BikeRack.Data;
using BikeRack.Interfaces;
using BikeRack.Repositories;
using BikeRack.Repositories.Interfaces;
using BikeRack.Services;
using BikeRack.Services.Interfaces;
using System.ComponentModel.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

object value = builder.Services.AddDbContext<AluguelContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AluguelDb"))
);

builder.Services.AddScoped<ICiclistaRepository, CiclistaRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<IGestaoAluguelRepository, GestaoAluguelRepository>();
builder.Services.AddScoped<ICartaoDeCreditoRepository, CartaoDeCreditoRepository>();
builder.Services.AddScoped<IHttpService, HttpService>();


builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
