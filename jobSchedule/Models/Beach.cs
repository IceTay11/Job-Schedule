using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jobSchedule.Models
{
    public class Beach
    {
        [Key]
        public int beachID { get; set; }

        [Required]
        public string beachName { get; set; }

        public int city_id { get; set; }

        [ForeignKey("city_id")]
        public City city { get; set; }



    }
}