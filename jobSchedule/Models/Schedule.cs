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

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime dutyStart { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime dutyEnd { get; set; }

        public int city_id { get; set; }
        [ForeignKey("city_id")]
        public City city { get; set; }

        public int beachID { get; set; }
        [ForeignKey("beachID")]
        public Beach beach { get; set; }

    }
}