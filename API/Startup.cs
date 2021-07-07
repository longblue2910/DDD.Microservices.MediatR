using API.Extensions;
using API.Validations;
using AutoMapper;
using Domain.Infrastructures.Handlers.Commands;
using Domain.Infrastructures.Mapping;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace API
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
            // Cấu hình FluentValidation
            services.AddControllers().AddFluentValidation();
            services.AddTransient<IValidator<CreateRoleCommand>, CreateRoleCommandValidator>(); ;
            // Add MediatR
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            // Add connectstring and Depency Injection
            services.AddDatabase(Configuration).
                     AddRepositories();
            // Add AutoMapper 
            var configurationExpression = new AutoMapper.Configuration.MapperConfigurationExpression();
            AppMapperConfiguration.RegisterMappings().ForEach(p => configurationExpression.AddProfile(p));
            var automapperConfig = new MapperConfiguration(configurationExpression);
            services.TryAddSingleton(automapperConfig.CreateMapper());
                
            //Add Validation
            

            //Add Swagger
            services.AddSwaggerGen(swagger => {
                //This is to generate the Default UI of Swagger Documentation  
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "JWT Token Authentication API",
                    Description = "ASP.NET Core 3.1 Web API"
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DDD API");
            });
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
