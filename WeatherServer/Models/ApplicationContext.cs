using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherServer.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Weather> Weathers { get; set; }
        public DbSet<WeatherForTime> WeatherForTimes { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
