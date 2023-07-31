using Azure.Core;
using ControlServices.API.Infrastructure.Filters;
using ControlServices.API.Infrastructure.Middlewares;
using ControlServices.Core.Models.Models.Errors;
using ControlServices.Core.Models.Responses;
using ControlServices.Infra.Data.Migrations;
using ControlServices.Infra.IoC;
using ControlServices.Infra.Utils.Utils;
using Microsoft.AspNetCore.Builder;
using System.Reflection;
using System.Reflection.PortableExecutable;

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
        EngineContext.Assembly = Assembly.GetExecutingAssembly().GetName().Name;

        // Filtro de exceptios
        services.AddMvc(options => 
        {
            options.Filters.Add(typeof(ExceptionFilter));
            options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(ResponseDTO<ErrorsModel>), 400));
            options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(ResponseDTO<ErrorsModel>), 401));
            options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(ResponseDTO<ErrorsModel>), 500));
        });

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
        app.UseSwagger(options =>
        {
            options.SerializeAsV2 = true;
        });

        //SwaggerUI
        app.UseSwaggerUI(c =>
        {
            //// Mudar request na mão 
            ////c.UseRequestInterceptor("(request) => { request.url =  console.log(request); return request; }");
            ////c.UseResponseInterceptor("(response) => { return response; }");
        });

        app.UseMiddleware<CultureMiddleware>();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
