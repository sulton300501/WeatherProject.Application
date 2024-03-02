using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherProject.Application.Abstractions;
using WeatherProject.Application.Abstractions.IServices;
using WeatherProject.Domain.Entities.DTOs;
using WeatherProject.Domain.Entities.Models;

namespace WeatherProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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


    }
}
