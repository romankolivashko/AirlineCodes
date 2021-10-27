using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Versioning;
//using Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer;
using System.Reflection;
using System.IO;
using System;
using AirportCodes.Models;

namespace AirportCodes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); 
            services.AddApiVersioning(x =>  
            {  
                //x.DefaultApiVersion = new ApiVersion(1, 0);  
                x.AssumeDefaultVersionWhenUnspecified = true;  
                x.ReportApiVersions = true;  
                //x.ApiVersionReader = new HeaderApiVersionReader("x-api-version");  
            });  
        

            services.AddSwaggerGen(options => 
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Swagger Demo API",
                        Description = "Demo API for showing Swagger",
                        Version = "v1"
                    });

                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                options.IncludeXmlComments(filePath);
            });

            services.AddDbContext<AirportCodesContext>(opt =>
                opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options => 
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo API");
                //options.RoutePrefix = "";
            });
        }
    }

    // public class VersioningConventions : IApplicationModelConvention
    // {   
    //     public void Apply(ApplicationModel application)
    //         {
    //             foreach (var controller in application.Controllers)
    //                 {
    //                     //Check if route attribute is alredy definedvar hasRoute = controller.Selectors.Any(selector => selector.AttributeRouteModel != null);if (hasRoute){continue;}//Get the version as last part of namespacevar version = controller.ControllerType.Namespace.Split('.').LastOrDefault();controller.Selectors[0].AttributeRouteModel = new AttributeRouteModel()       
    //                 {  
    //                 Template = string.Format("api/{0}/{1}", version, controller.ControllerName);  
    //             };  
    //         }  
    //     }  
    // }  
}




