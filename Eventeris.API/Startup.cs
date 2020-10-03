using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventeris.BLL.Services;
using Eventeris.DAL.Entidade;
using Eventeris.DAL.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System.Security.Principal;
using Eventeris.DAL.Interface;

namespace Eventeris.API
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
			 // Usa o especifico
            services.AddScoped<RepositorioParticipante>();
            //services.AddScoped<IRepositorioParticipante, RepositorioParticipante>();
            services.AddScoped<RepositorioEvento>();
            //services.AddScoped<IRepositorioEvento, RepositorioEvento>();
            services.AddScoped<IRepositorioComum<Evento>, RepositorioComum<Evento>>();
            services.AddScoped<IRepositorioComum<Participacao>, RepositorioComum<Participacao>>(); // cria instâncias genericas
            services.AddScoped<IRepositorioComum<CategoriaEvento>, RepositorioComum<CategoriaEvento>>(); // cria instâncias genericas
            services.AddScoped<IRepositorioComum<StatusEvento>, RepositorioComum<StatusEvento>>(); // cria instâncias genericas

            //Adiciona os servicos
            services.AddTransient<EventoService>();
            services.AddTransient<ParticipanteService>();
            services.AddTransient<CategoriaService>();

            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Eventeris", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto Eventeris V1");
            });
        }
    }
}
