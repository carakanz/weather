using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherServer.Models
{
    public class Weather
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Index]
        public virtual City City { get; set; }
        public ICollection<WeatherForTime> WeatherInfos { get; set; }

        [Required]
        public WeatherInfo Current { get; set; }
    }
}
