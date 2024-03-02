using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherProject.Domain.Entities.DTOs;
using WeatherProject.Domain.Entities.Models;

namespace WeatherProject.Application.Abstractions
{
    public interface IWeatherRepository : IBaseRepository<Weather>
    {

    }
}
