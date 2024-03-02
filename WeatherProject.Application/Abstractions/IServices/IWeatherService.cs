using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeatherProject.Domain.Entities.DTOs;
using WeatherProject.Domain.Entities.Models;

namespace WeatherProject.Application.Abstractions.IServices
{
    public interface IWeatherService
    {
        public Task<Weather> Create(Weather weather);
        public Task<Weather> GetByAny(Expression<Func<Weather, bool>> expression);
        public Task<IEnumerable<Weather>> GetAll();
        public Task<bool> Delete(Expression<Func<Weather, bool>> expression);
        public Task<Weather> Update(int id,WeatherDTO weatherDTO);

    }
}
