namespace jobSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "city_name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "city_name");
        }
    }
}
