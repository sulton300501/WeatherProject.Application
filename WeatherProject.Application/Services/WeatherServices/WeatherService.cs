using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeatherProject.Application.Abstractions;
using WeatherProject.Domain.Entities.Models;

namespace WeatherProject.Application.Services.WeatherServices
{
    public class WeatherService : IWeatherRepository
    {
        public Task<Weather> Create(Weather entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Expression<Func<Weather, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Weather>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Weather> GetByAny(Expression<Func<Weather, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Weather> Update(Weather entity)
        {
            throw new NotImplementedException();
        }
    }
}
