using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherProject.Application.Abstractions;
using WeatherProject.Domain.Entities.Models;
using WeatherProject.Infrastructura.Persistance;

namespace WeatherProject.Infrastructura.BaseRepository
{
    public class WeatherRepository : BaseRepository<Weather>, IWeatherRepository
    {
        public WeatherRepository(WeatherProjectsDbContext context) : base(context)
        {

        }
    }
}
