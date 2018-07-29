namespace jobSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "dutyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedules", "timeStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedules", "timeEnd", c => c.DateTime(nullable: false));
            DropColumn("dbo.Schedules", "dutyStart");
            DropColumn("dbo.Schedules", "dutyEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "dutyEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedules", "dutyStart", c => c.DateTime(nullable: false));
            DropColumn("dbo.Schedules", "timeEnd");
            DropColumn("dbo.Schedules", "timeStart");
            DropColumn("dbo.Schedules", "dutyDate");
        }
    }
}
