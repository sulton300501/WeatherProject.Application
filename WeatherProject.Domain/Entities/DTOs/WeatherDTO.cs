﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherProject.Domain.Entities.DTOs
{
    public class WeatherDTO
    {

        public string CityName { get; set; }
        public string CloudCondition { get; set; }

        public int WindSpeed { get; set; }
        public string SunShine { get; set; }
        public string Role {  get; set; }

    }
}
