/* Javier Suárez Guzmán
 * Mayo 2023 */

/*En ASP.NET Core, los servicios (como el contexto de la base de
 * datos) deben registrarse con el contenedor de inserción de dependencias (DI). 
 * El contenedor proporciona el servicio a los controladores.*/

using Microsoft.EntityFrameworkCore;
using API_tareas.Models;
/*Agrega el contexto de base de datos para el contenedor de DI.
Especifica que el contexto de base de datos usará una base de datos en memoria.*/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AlumnoDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
builder.Services.AddDbContext<TareaContext>(opt =>
    opt.UseInMemoryDatabase("TareaList"));
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
