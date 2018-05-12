using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace jobSchedule.Models
{
    public class City
    {
        [Key]
        public int city_id { get; set; }

        [Required]
        public string city_name { get; set; }

        [Required]
        public string province { get; set; }
               


    }
}