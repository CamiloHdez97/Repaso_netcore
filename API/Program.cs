using Microsoft.Extensions.Options;
using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using API.Extensions;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors();

builder.Services.AddControllers();
builder.Services.AddAplicationServices();

builder.Services.AddDbContext<InventarioContext>(Options => {
    
    //Archivo de configuración
    string connectionString = builder.Configuration.GetConnectionString("ConexMysql");
    Options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

});

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
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
