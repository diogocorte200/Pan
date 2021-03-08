using BancoPan.Domain.Services;
using BancoPan.Domain.Services.Generic;
using BancoPan.Entity.Context;
using BancoPan.Entity.Repositories;
using BancoPan.Entity.Repositories.Interfaces;
using BancoPan.Entity.UnitofWork;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoPan.Domain.Mapping;
using BancoPan.Domain.Interfaces;

namespace BancoPan
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                      new OpenApiInfo
                      {
                          Title = "Webservices clientes",
                          Version = "v1",
                          Description = "Services clientes",
                          Contact = new OpenApiContact
                          {
                              Name = "Diogo Rodrigues",
                          }
                      });

            });


            services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(Configuration["ConnectionStrings:clienteDB"]);
                config.UseSerializerSettings(new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            });
            
            services.AddDbContext<ClienteContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:clienteDB"]));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(ClienteService<,>), typeof(ClienteService<,>));
            services.AddTransient(typeof(IServiceAsync<,>), typeof(GenericServiceAsync<,>));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IEnderecoRepository, EnderecoRepository>();
            services.AddHttpClient<IViaCepService, ViaCepService>();
            services.AddTransient<IViaCepService, ViaCepService>();
            services.AddHttpClient<IIbgeService, IbgeService>();
            services.AddTransient<IIbgeService, IbgeService>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddHttpContextAccessor();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Service Cadastro");
            });
        }
    }
}
