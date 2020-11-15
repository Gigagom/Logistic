using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using logistic_app_api.Data;
using logistic_app_api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace logictic_app_api
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
            services.AddDbContext<LogisticContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("LogisticConnction")));
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:8080");
                    });
            });

            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IRepository<BorderCrossing>, BorderCrossingsRepository>();
            services.AddScoped<IRepository<Car>, CarsRepository>();
            services.AddScoped<IRepository<Client>, ClientsRepository>();
            services.AddScoped<IRepository<Customs>, CustomsRepository>();
            services.AddScoped<IRepository<Declarant>, DeclarantsRepository>();
            services.AddScoped<IRepository<Destination>, DestinationsRepository>();
            services.AddScoped<IRepository<Trailer>, TrailersRepository>();
            services.AddScoped<IRepository<User>,UsersRepository>();
            services.AddScoped<IRepository<DeliveryTask>, DeliveryTasksRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
