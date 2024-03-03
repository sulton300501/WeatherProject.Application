using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherProject.Domain.Entities.DTOs;
using WeatherProject.Domain.Entities.Models;

namespace WeatherProject.Application.Abstractions.IServices
{
    public interface IAuthService
    {
        public Task<string> GenerateToken(WeatherDTO weather);
    }
}
