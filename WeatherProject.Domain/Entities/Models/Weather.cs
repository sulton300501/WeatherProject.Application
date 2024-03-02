﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherProject.Domain.Entities.Models
{
    public class Weather
    {
        public int Id { get; set; }
        public string? CityName { get; set; }
        public string? CloudCondition { get; set; }

        public string? WindSpeed { get; set; }
        public string? SunShine { get; set; }

    }
}
