using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeatherProject.Application.Abstractions;
using WeatherProject.Application.Abstractions.IServices;
using WeatherProject.Application.Services.WeatherServices;
using WeatherProject.Infrastructura.BaseRepository;
using WeatherProject.Infrastructura.Persistance;

namespace WeatherProject.Infrastructura
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<WeatherProjectsDbContext>(options =>
            {
                options.UseNpgsql(conf.GetConnectionString("WeatherProjectsConnectionString"));

            });

            services.AddScoped<IWeatherRepository,WeatherRepository>();


            return services;




        }
    }
}
