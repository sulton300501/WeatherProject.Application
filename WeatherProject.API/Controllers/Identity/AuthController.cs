using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherProject.Application.Abstractions.IServices;
using WeatherProject.Domain.Entities.DTOs;
using WeatherProject.Domain.Entities.Models;

namespace WeatherProject.API.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }



        [HttpPost]
        public IActionResult WideSpeed(WeatherDTO weather)
        {
            var result = _authService.GenerateToken(weather);
            return Ok(result);
        }


      







    }
}
