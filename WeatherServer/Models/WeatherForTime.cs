using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherServer.Models
{
    public class WeatherForTime
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime Time { get; set; }
        public WeatherInfo Weather { get; set; }
    }
}
