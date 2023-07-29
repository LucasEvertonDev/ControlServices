﻿using ControlServices.API.Filter;
using ControlServices.API.Middlewares;
using ControlServices.Infra.IoC;
using Microsoft.AspNetCore.Builder;

namespace ControlServices.API.Infrastructure;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Filtro de exceptios
        services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));
        // pra usar o middleware que não é attributee
        services.AddHttpContextAccessor();
        // Add services to the container.
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();

        services.AddInfrastructureAPI(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

        //Swagger
        app.UseSwagger();

        //SwaggerUI
        app.UseSwaggerUI();

        app.UseMiddleware<CultureMiddleware>();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
