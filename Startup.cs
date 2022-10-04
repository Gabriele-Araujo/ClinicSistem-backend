using ClinicSistem_backend.Data;
using ClinicSistem_backend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace ClinicSistem_backend
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
            

            services.AddDbContext<ClinicContext>(opts => opts.UseLazyLoadingProxies()
                    .UseMySQL(Configuration.GetConnectionString("DefaultConnection")));


            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder => builder.WithOrigins("http://localhost:4201"));
                options.AddPolicy("mypolicy", builder =>
                    builder.WithOrigins("http://localhost:4200"));
            }
            );


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClinicSistem_backend", Version = "v1" });
            });
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<AgendaService, AgendaService>();
            services.AddScoped<ClinicaService, ClinicaService>();
            services.AddScoped<CronogramaService, CronogramaService>();
            services.AddScoped<DentistaService, DentistaService>();
            services.AddScoped<PacienteService, PacienteService>();
            services.AddScoped<ProcedimentoService, ProcedimentoService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClinicSistem_backend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("mypolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors("mypolicy");
            });
        }
    }
}
