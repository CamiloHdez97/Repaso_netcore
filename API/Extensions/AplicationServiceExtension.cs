using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Estities;
using Core.interfaces;
using Infrastucture.Repository;
using Infrastucture.UnitOfWork;
namespace API.Extensions;

public static class ApplicationServiceExtension
{
        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
               builder.AllowAnyOrigin()    //WithOrigins("https://domini.com")
               .AllowAnyMethod()           //WithMethods(*GET", "POST")
               .AllowAnyHeader());         //WithHeaders(*accept*, "content-type")
        });  

        public static void AddAplicationServices(this IServiceCollection services){

                services.AddScoped<IUnitOfWork, UnitOfWork>();
                
        }
}