using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApplication1.V2.Models;
using NJsonSchema;
using NSwag.AspNetCore;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace WebApplication1
{
    /// <summary>
    /// Represents the startup process for the application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Get the current configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures services for the application.
        /// </summary>
        /// <param name="services">The collection of services to configure the application with.</param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
                            opt.UseInMemoryDatabase("TodoList"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region Versioning
            services.AddApiVersioning(
                options =>
                {
                    options.AssumeDefaultVersionWhenUnspecified = false;
                    // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                    options.ReportApiVersions = true;
                    options.ApiVersionReader = new UrlSegmentApiVersionReader();
                });
            services.AddVersionedApiExplorer(
                options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "VVVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });

            #endregion

            services.AddSwaggerDocument(document =>
            //{
            //    document.PostProcess = d => d.Info.Title = "Hello world!";
            //});
                {
                    document.DocumentName = "v1.0";
                    document.ApiGroupNames = new[] { "1.0" };
                    document.Version = "1.0";
                    document.PostProcess = d => d.Info.Title = "Hello world!";
                })
                .AddSwaggerDocument(document =>
                {
                    document.DocumentName = "v2.0";
                    document.ApiGroupNames = new[] { "2.0" };
                    document.Version = "2.0";
                    document.PostProcess = d => d.Info.Title = "Bye world!";
                })
                //.AddSwaggerDocument(document =>
                //{
                //    document.DocumentName = "v3.0";
                //    document.ApiGroupNames = new[] { "3.0" };
                //    document.PostProcess = d => d.Info.Title = "LOL!";
                //})
                ;
        }

        /// <summary>
        /// Configures the application using the provided builder, hosting environment, and API version description provider.
        /// </summary>
        /// <param name="app">The current application builder.</param>
        /// <param name="env">The current hosting environment.</param>
        /// <param name="provider">The API version descriptor provider used to enumerate defined API versions.</param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUi3( config =>
            {
                config.SwaggerRoutes.Add(new SwaggerUi3Route("v1.0", "/swagger/v1.0/swagger.json"));
                config.SwaggerRoutes.Add(new SwaggerUi3Route("v2.0", "/swagger/v2.0/swagger.json"));
            });

        }
    }
}
