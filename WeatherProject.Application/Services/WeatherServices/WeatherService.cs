using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeatherProject.Application.Abstractions;
using WeatherProject.Application.Abstractions.IServices;
using WeatherProject.Domain.Entities.DTOs;
using WeatherProject.Domain.Entities.Models;

namespace WeatherProject.Application.Services.WeatherServices
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public async Task<Weather> Create(WeatherDTO weatherDTO)
        {
            var weather = new Weather()
            {
                CityName = weatherDTO.CityName,
                CloudCondition = weatherDTO.CloudCondition,
                WindSpeed = weatherDTO.WindSpeed,
                SunShine = weatherDTO.SunShine,
            };
            var result = await _weatherRepository.Create(weather);
            return result;
        }

        public async Task<bool> Delete(Expression<Func<Weather, bool>> expression)
        {
            var result = await _weatherRepository.Delete(expression);
            return result;
        }

        public async Task<List<Weather>> GetAll()
        {
           var res = await _weatherRepository.GetAll();
            return res;
        }

        public async Task<Weather> GetByAny(Expression<Func<Weather, bool>> expression)
        {
           var result = await _weatherRepository.GetByAny(expression);
            return result;
        }

        public async Task<Weather> GetByCloudCondition(string condition)
        {
            var result = await _weatherRepository.GetByAny(x=>x.CloudCondition==condition);
            return result;
        }

        public async Task<Weather> GetById(int id)
        {
           var result = await _weatherRepository.GetByAny(x=>x.Id == id);
            return result;
        }

        public async Task<Weather> GetByName(string name)
        {
           var result = await _weatherRepository.GetByAny(x=>x.CityName == name);
            return result;
        }

        public async Task<Weather> Update(int id, WeatherDTO weatherDTO)
        {
            var res =await _weatherRepository.GetByAny(x=>x.Id==id);

            if (res != null)
            {

                res.CityName = weatherDTO.CityName;
                res.CloudCondition = weatherDTO.CloudCondition;
                res.WindSpeed = weatherDTO.WindSpeed;
                res.SunShine = weatherDTO.SunShine;

              
                var result = await _weatherRepository.Update(res);
                return result;
            }
            return new Weather();


         
          
        }
    }
}
