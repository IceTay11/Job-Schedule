using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace jobSchedule.Models
{
    public class Lifeguard
    {
        [Key]
        [Display(Name ="LifeguardID")]
        public int lifeguardID { get; set; }

        [Required]
        public string Lifeguard_Name { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        public string gender { get; set; }

        public int city_id { get; set; }
        [ForeignKey("city_id")]
        public City city { get; set; }
        
    }
}