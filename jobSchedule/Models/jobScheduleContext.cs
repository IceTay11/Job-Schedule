using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace jobSchedule.Models
{
    public class jobScheduleContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public jobScheduleContext() : base("name=jobScheduleContext")
        {
        }

        public System.Data.Entity.DbSet<jobSchedule.Models.City> Cities { get; set; }

        public System.Data.Entity.DbSet<jobSchedule.Models.Lifeguard> Lifeguards { get; set; }

        public System.Data.Entity.DbSet<jobSchedule.Models.Schedule> Schedules { get; set; }

        public System.Data.Entity.DbSet<jobSchedule.Models.Beach> Beaches { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
