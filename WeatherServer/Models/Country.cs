using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherServer.Models
{
    public class Country
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Index]
        [Column("name_ru")]
        public string NameRu { get; set; }
        [Required]
        [Index]
        [Column("name_en")]
        public string NameEn { get; set; }
    }
}
