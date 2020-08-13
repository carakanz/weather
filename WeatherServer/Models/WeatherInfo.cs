using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherServer.Models
{
    [Owned]
    public class WeatherInfo
    {
        [Required]
        public int Temp { get; set; }
        [Required]
        [Column("feels_like")]
        public int FeelsLike { get; set; }
        [Required]
        [Column("temp_min")]
        public int TempMin { get; set; }
        [Required]
        [Column("temp_max")]
        public int TempMax { get; set; }
        [Required]
        public int Pressure { get; set; }
        [Required]
        public int Humidity { get; set; }
        [Required]
        public int Visibility { get; set; }
        [Required]
        [Column("wind_speed")]
        public int WindSpeed { get; set; }
        [Required]
        [Column("wind_deg")]
        public int WindDeg { get; set; }
        [Required]
        /*
         * 1 - нет
         * 2 - слабо
         * 3 - средне
         * 4 - сильно 
         */
        public int Clouds { get; set; }
        [Required]
        /*
         * битовая маска
         * сила
         * 0 - нет
         * 1 - легкий
         * 2 - средний
         * 3 - сильный
         * тип
         * 2^0 - дождь
         * 2^2 - снег
         * 2^4 - град
         */
        public int Rain { get; set; }
        [Required]
        public DateTime Sunrise { get; set; }
        [Required]
        public DateTime Sunset { get; set; }
    }
}
