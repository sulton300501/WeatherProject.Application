using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WeatherProject.Application.Abstractions.IServices;
using WeatherProject.Domain.Entities.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace WeatherProject.Application.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _conf;
        private readonly IWeatherService _weatherService;

        public AuthService(IConfiguration conf, IWeatherService weatherService)
        {
            _conf = conf;
            _weatherService = weatherService;
        }



        public async Task<string> GenerateToken(Weather weather)
        {
            if(weather == null)
            {
                throw new ArgumentNullException("user");
            }

            if(await UserExist(weather))
            {

               // var res = await _weatherService.GetWindSpeed();

                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Role, weather.Role),
                    new Claim("CityName",weather.CityName),
                    new Claim("WeatherId",weather.Id.ToString()),
                    new Claim("CreateDate", DateTime.UtcNow.ToString()),




                };
                return await GenerateToken(claims);
            }
            else
            {
                return "User Unauthorize 401";
            }
            


        }




        public async Task<string> GenerateToken(IEnumerable<Claim> additionalClaims)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var exDate = Convert.ToInt32(_conf["JWT:ExpireDate"] ?? "10");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                 new Claim(JwtRegisteredClaimNames.Iat , EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture))

            };

            if (additionalClaims?.Any() == true)
                claims.AddRange(additionalClaims);

            var token = new JwtSecurityToken(
                issuer: _conf["JWT:ValidIssuer"],
                audience: _conf["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(exDate),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);







        }





        private async Task<bool> UserExist(Weather weather)
        {
            var maxWind = 1;
           // var res = await _weatherService.GetWindSpeed(weather.WindSpeed);
          

           // var windSpeed = Convert.ToDecimal(weather.WindSpeed);

            if (maxWind < weather.WindSpeed)
            {
                return true;
            }

            return false;
        }



    }
}
