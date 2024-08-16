using Application.IServices;
using Application.Services;
using Domain.IRepositories;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BibliotecaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IPrestamoService, PrestamoService>();
builder.Services.AddScoped<IPrestamoRepository, PrestamoRepository>();

builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<ILibroRepository, LibroRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
