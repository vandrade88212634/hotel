using Common.Utils.JWT;
using Dominio.Servicio.Servicios;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using planeador.seguridad.webapi.Handlers;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using planeador.seguridad.webapi;
using Dominio.Servicio.Dependency;
using Common.Utils.Utils;
using Common.Utils.Utils.Interface;

internal class Program
{

    private static void Main(string[] args)
    {

       
        
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
         
    builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddInfraestructuraServices(builder.Configuration);
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );
        });

        
        var app = builder.Build();
        

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
            app.UseSwagger();
            app.UseSwaggerUI();
        //}

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseCors("CorsPolicy");


        app.MapControllers();

        app.Run();
    }

    
}