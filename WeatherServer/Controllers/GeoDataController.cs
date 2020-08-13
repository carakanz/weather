using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherServer.Models;

namespace WeatherServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoDataController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public GeoDataController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/GeoData/country?country=Rus
        [HttpGet("country")]
        public async Task<ActionResult<ICollection<string>>> GetCountries(
            [FromQuery][StringLength(60, MinimumLength = 2)] string country)
        {
            country = country.ToLower();
            var countries = await _context.Countries
                .Where(c => c.NameEn.StartsWith(country))
                .Select(c => c.NameEn)
                .Take(10)
                .ToListAsync();

            if (countries.Count() != 0)
            {
                return countries;
            }

            countries = await _context.Countries
                .Where(c => c.NameRu.StartsWith(country))
                .Select(c => c.NameRu)
                .Take(10)
                .ToListAsync();

            if (countries.Count() != 0)
            {
                return countries;
            }

            return NotFound();
        }

        // GET: api/GeoData/region?country=Rus&region=Mos
        [HttpGet("Region")]
        public async Task<ActionResult<ICollection<string>>> GetRegiones(
            [FromQuery] string country,
            [FromQuery][StringLength(60, MinimumLength = 2)] string region)
        {
            country = country?.ToLower();
            region = region.ToLower();
            var regiones = _context.Regions.AsQueryable();
            if (!string.IsNullOrEmpty(country))
            {
                var countries = _context.Countries
                .Where(c => c.NameEn.StartsWith(country) 
                         || c.NameRu.StartsWith(country));

                regiones = regiones
                .Where(r => countries.Contains(r.Country));
            }

            var regionesNames = await regiones
                .Where(r => r.NameEn.StartsWith(region))
                .Select(r => r.NameEn)
                .Take(10)
                .ToListAsync();

            if (regionesNames.Count() != 0)
            {
                return regionesNames;
            }

            regionesNames = await regiones
                .Where(r => r.NameRu.StartsWith(region))
                .Select(r => r.NameRu)
                .Take(10)
                .ToListAsync();

            if (regionesNames.Count() != 0)
            {
                return regionesNames;
            }

            return NotFound();
        }

        // GET: api/GeoData/city?country=Rus&region=Mos&city=Mos
        [HttpGet("City")]
        public async Task<ActionResult<ICollection<string>>> GetCity(
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

            var citiesNames = await cities
                .Where(r => r.NameEn.StartsWith(city))
                .Select(r => r.NameEn)
                .Take(10)
                .ToListAsync();

            if (citiesNames.Count() != 0)
            {
                return citiesNames;
            }

            citiesNames = await cities
                .Where(r => r.NameRu.StartsWith(city))
                .Select(r => r.NameRu)
                .Take(10)
                .ToListAsync();

            if (citiesNames.Count() != 0)
            {
                return citiesNames;
            }

            return NotFound();
        }
    }
}
