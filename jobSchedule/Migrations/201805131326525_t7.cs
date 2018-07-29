namespace jobSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t7 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Schedules", "city_id");
            AddForeignKey("dbo.Schedules", "city_id", "dbo.Cities", "city_id");
            DropColumn("dbo.Schedules", "city_name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "city_name", c => c.String());
            DropForeignKey("dbo.Schedules", "city_id", "dbo.Cities");
            DropIndex("dbo.Schedules", new[] { "city_id" });
        }
    }
}
