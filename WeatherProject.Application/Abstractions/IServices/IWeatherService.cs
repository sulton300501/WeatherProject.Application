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
        public Task<Weather> Create(WeatherDTO weatherDTO);
        public Task<Weather> GetByName(string name);

        public Task<Weather> GetById(int id);
        public Task<Weather> GetWindSpeed(int wind);

        public Task<Weather> GetByCloudCondition(string condition);

        public Task<List<Weather>> GetAll();
        public Task<bool> Delete(Expression<Func<Weather, bool>> expression);
        public Task<Weather> Update(int id, WeatherDTO weatherDTO);

    }
}
