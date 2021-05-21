using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    public class WeatherDetail
    {
        [Key]
        public string City { get; set; }
        public int WeatherID { get; set; }
        public DateTime Date { get; set; }
        public int HighTemp { get; set; }
        public int LowTemp { get; set; }
        public string ForCast { get; set; }
    }
}
