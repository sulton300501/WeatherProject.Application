﻿using EmailSenderApp.API.Atributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WeatherProject.Application.Abstractions;
using WeatherProject.Application.Abstractions.IServices;
using WeatherProject.Domain.Entities.DTOs;
using WeatherProject.Domain.Entities.Enums;
using WeatherProject.Domain.Entities.Models;

namespace WeatherProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]

    public class WeatherController : ControllerBase
    {

        private readonly IWeatherService _weatherService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WeatherController(IWeatherService weatherService, IWebHostEnvironment webHostEnvironment)
        {
            _weatherService = weatherService;
            _webHostEnvironment = webHostEnvironment;
        }


        List<string> quyosh = new List<string>()
        {
            "Quyosh 1","Quyosh 2","Quyosh 3","Quyosh 4"
        };

        List<string> yulduz = new List<string>()
        {
            "Yulduz 1","Yulduz 2","Yulduz 3","Yulduz 4"
        };


        /*   [HttpGet]

           public IActionResult GetQuyosh()
           {
               return Ok(quyosh);
           }

           [HttpGet]

           public IActionResult GetYulduz()
           {
               return Ok(yulduz);
           }*/



        /*   [HttpGet]
           [IdentifyFilter(Permission.GetAllStudents)]
           public IActionResult GetMoons()
           {
               return Ok(quyosh);
           }

           [HttpPost]
           [IdentifyFilter(Permission.CreateStudent)]
           public IActionResult GreateStars()
           {
               return Ok("create boldi");
           }
   */
        /* [HttpPost]
         [IdentifyFilter()]
         public IActionResult DeleteStars()  
         {
             return Ok("Delete boldi");
         }*/






        [HttpGet]
        [IdentifyFilter(Permission.GetAllWeather)]
        public async Task<ActionResult<IEnumerable<Weather>>> GetAllWeather()
        {
            var result = await _weatherService.GetAll();

            return Ok(result);
        }


        [HttpPost]
        [IdentifyFilter(Permission.CreateWeather)]
        public async Task<ActionResult<IEnumerable<Weather>>> CreateWeather([FromForm] WeatherDTO model)
        {
            model.ImageUrl = model.Image.FileName;
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "image", model.ImageUrl);

            using var stream = System.IO.File.Create(path);
            {
                model.Image.CopyTo(stream);
            }


            /*  image.CopyTo(Path.Combine(_webHostEnvironment.WebRootPath, "image", image.FileName));*/
            var result = await _weatherService.Create(model);

            return Ok(result);
        }

        [HttpDelete]
        [IdentifyFilter(Permission.DeleteWeather)]
        public async Task<ActionResult<IEnumerable<Weather>>> DeleteWeather(int id)
        {
            Expression<Func<Weather, bool>> predicate = x => x.Id == id;
            var result = await _weatherService.Delete(predicate);

            return Ok(result);
        }


        [HttpPut]
        [IdentifyFilter(Permission.UpdateWeather)]
        public async Task<ActionResult<IEnumerable<Weather>>> UpdateWeather(int id, WeatherDTO model)
        {
            var result = await _weatherService.Update(id, model);

            return Ok(result);
        }




    }
}
