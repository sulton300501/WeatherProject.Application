using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherProject.Domain.Entities.Models;

namespace WeatherProject.Infrastructura.Persistance
{
    public class WeatherProjectsDbContext:DbContext
    {
        public WeatherProjectsDbContext(DbContextOptions<WeatherProjectsDbContext> options):base(options)
        {
         Database.Migrate();
        }
     
        public DbSet<Weather> Weathers { get; set; }
    }

    
}
