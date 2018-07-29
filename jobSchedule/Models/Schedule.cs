using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jobSchedule.Models
{
    public class Schedule
    {
        [Key]
        public int scheduleID { get; set; }

        public int lifeguardID { get; set; }
        [ForeignKey("lifeguardID")]
        public Lifeguard lifeguard { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime dutyDate { get; set; }

        [Required]
        [DataType(DataType.Time)] 
        public DateTime timeStart { get; set; }

        [Required]
        [DataType(DataType.Time)] 
        public DateTime timeEnd { get; set; }

        [Required]
        public int city_id { get; set; }

        public virtual City city { get; set; }

        public int beachID { get; set; }
        [ForeignKey("beachID")]
        public Beach beach { get; set; }

    }
}