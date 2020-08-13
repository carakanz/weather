using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherServer.Models;

namespace WeatherServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public WeatherController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/weather/get?country=Rus&region=Mos&city=Mos
        [HttpGet("get")]
        public async Task<ActionResult<Weather>> GetWeather(
            [FromQuery] string country,
            [FromQuery] string region,
            [FromQuery][StringLength(60, MinimumLength = 2)] string city)
        {
            country = country?.ToLower();
            region = region?.ToLower();
            city = city.ToLower();
            var cities = _context.Cities.AsQueryable();
            if (!string.IsNullOrEmpty(country))
            {
                var countries = _context.Countries
                .Where(c => c.NameEn.StartsWith(country) 
                         || c.NameRu.StartsWith(country));

                cities = cities
                .Where(c => countries.Contains(c.Country));
            }

            if (!string.IsNullOrEmpty(region))
            {
                var regiones = _context.Regions
                .Where(r => r.NameEn.StartsWith(region) 
                         || r.NameRu.StartsWith(region));

                cities = cities
                .Where(c => regiones.Contains(c.Region));
            }

            var trueCity = await cities
                .Where(c => c.NameEn.StartsWith(city) ||
                            c.NameRu.StartsWith(city))
                .FirstOrDefaultAsync();
            if (trueCity is null)
            {
                return NotFound();
            }

            var weather = await _context.Weathers
                .Where(w => w.City == trueCity)
                .Include(w => w.City)
                .Include(w => w.City.Region)
                .Include(w => w.City.Country)
                .Include(w => w.WeatherInfos)
                .FirstOrDefaultAsync();
            return weather;
        }
    }
}
