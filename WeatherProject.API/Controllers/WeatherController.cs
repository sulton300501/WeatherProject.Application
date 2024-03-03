using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WeatherProject.Application.Abstractions;
using WeatherProject.Application.Abstractions.IServices;
using WeatherProject.Domain.Entities.DTOs;
using WeatherProject.Domain.Entities.Models;

namespace WeatherProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class WeatherController : ControllerBase
    {   
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weather>>> GetAllWeather()
        {
            var result = await _weatherService.GetAll();

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<Weather>>> CreateWeather(WeatherDTO model)
        {
            var result = await _weatherService.Create(model);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Weather>>> DeleteWeather(int id)
        {
            Expression<Func<Weather, bool>> predicate = x => x.Id == id;
            var result = await _weatherService.Delete(predicate);

            return Ok(result);
        }


        [HttpPut]
        public async Task<ActionResult<IEnumerable<Weather>>> UpdateWeather(int id,WeatherDTO model)
        {
            var result = await _weatherService.Update(id,model);

            return Ok(result);
        }




    }
}
